# Sub-Wrecker
Convert Barotrauma submarines to wrecks. 
## Installation
### Prerequisites
- Python 3.6+
### Instructions
1. Download the files from either the latest release and extracting, or by cloning the repo.
## Usage
Sub-Wrecker is run from the command line. Simply run `python Sub-Wrecker.py -h` to see the following message:  
```
usage: Sub-Wrecker.py [-h] [-i] files [files ...]

Wreck all possible things that can be wrecked on a submarine in Barotrauma.

positional arguments:
  files          The files to be converted.

optional arguments:
  -h, --help     show this help message and exit
  -i, --inplace
```
It can take any number of files as input and will attempt to wreck all of them.  
Some examples:  
- Wreck a single .sub `python Sub-Wrecker.py Dugong.sub`
- Wreck a single .sub, inplace `python Sub-Wrecker.py -i Dugong.sub`
- Wreck a single .xml `python Sub-Wrecker.py Dugong.xml`
- Wreck two .subs `python Sub-Wrecker.py Dugong.sub Orca.sub`
- Wreck two .subs, inplace `python Sub-Wrecker.py -i Dugong.sub Orca.sub`