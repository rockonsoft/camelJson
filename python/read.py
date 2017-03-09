#!/usr/bin/python
import json
import sys
from pprint import pprint


def test_json_read(fileName):
    with open(fileName) as data_file:    
        list = json.load(data_file)

        for person in list:
            print('Title: ' + person["title"])
            print('FirstName: ' + person["firstName"])
            print('LastName: ' + person["lastName"])

if __name__ == "__main__":
   test_json_read(sys.argv[1])
