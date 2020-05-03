#!/usr/bin/env python3
import argparse
import gzip
from os import path
import re
import xml.etree.ElementTree as ET

from IDENTIFIERS import IDENTIFIERS
from TAGS import TAGS

parser = argparse.ArgumentParser(
    description="Wreck all possible things that can be wrecked on a submarine in Barotrauma."
)
parser.add_argument("files", nargs="+", type=str, help="The files to be converted.")
parser.add_argument("-i", "--inplace", action="store_true")

if __name__ == "__main__":
    args = parser.parse_args()
    for file in args.files:
        print(f"Attempting to wreck {file}...")
        if not path.isfile(file):
            # Ignore non-files
            print(f"Cannot find {file}, skipping.")
            continue

        splitext = path.splitext(file)
        filename = splitext[0]
        extension = splitext[-1].lower()
        # Only work on .subs and .xmls for safety
        if extension == ".sub":
            with gzip.open(file, "rb") as sub:
                sub_xml = sub.read()
        elif extension == ".xml":
            with open(file, "r") as sub:
                sub_xml = sub.read()
        else:
            print(f"File {file} has unsupported file extension, skipping.")
            continue

        # Run the conversions
        print(f"Wrecking {file}...")
        tree = ET.fromstring(sub_xml)
        for node in tree.iter():
            value = str(node.attrib.get("identifier", ""))
            if value in IDENTIFIERS:
                # print(f"Wrecking {value} ==> {IDENTIFIERS[value]}")
                node.attrib["identifier"] = IDENTIFIERS[value]

            value = node.attrib.get("tags")
            if value and [value for sub in TAGS.keys() if sub in value] != list():
                for tag, wrecktag in TAGS.items():
                    regex = re.compile(f'(?:(?<=[,"])|^){tag}(?:(?=[,"])|$)')
                    value = regex.sub(wrecktag, value)
                node.attrib["tags"] = value

        # Convert back to a string for writing to file
        wrecked_xml = ET.tostring(tree)

        # If not inplace, make a " - Wrecked" suffix
        if not args.inplace:
            out_file = f"{filename} - Wrecked{extension}"
        else:
            out_file = file

        print(f"Saving to {out_file}...")
        # Save the submarine to the file we decided on
        if extension == ".sub":
            with gzip.open(out_file, "wb+") as sub:
                sub.write(wrecked_xml)
        else:
            with open(out_file, "wb+") as sub:
                sub.write(wrecked_xml)
        print(f"Completed {file}.")
