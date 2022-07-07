# Converter

This programm finds common byte sequenses in any count of files(2,3..100+)

How its work
Lets take 4 file for example:

  File name:  1.txt     2.txt     3.txt     4.txt
  
  Content:    gktidnr   232345r   HELLO3r   tHge%EL
              HELLOfe   fdhtHEL   e2#tstg   ftOrfdg
              grqwee    LOngfky   $@fav5g   HELLOgt
              
Program convert 1st file into byte array, enumerate 1 file by bytes
lets see step by step:
We want seek common sequence lenght = 5 word

1 step:
  1.txt => sequence 5 word = qktid
2 step: 
  seek for qktid in 2.txt, 3.txt, 4.txt
3 step:
  there no such sequence (qktid) in other file
4 step:
  1.txt => shift the sequence by 1 byte = ktidn
5 step
  seek for ktidn in 2.txt, 3.txt, 4.txt
6 step:
  there no such sequence (ktidn) in other file
7 step:
  1.txt => shift the sequence by 1 byte = tidnr
8 step
  seek for tidnr in 2.txt, 3.txt, 4.txt
9 step:
  there no such sequence (tidnr) in other file
  
....and so on till sequence HELLO....

10 step:
  1.txt => shift the sequence by 1 byte = HELLO
11 step: 
  seek for qktid in 2.txt, 3.txt, 4.txt
12 step:
  Found sequence in every file
13 step: 
  Write sequence in outlog file
14 step
   1.txt => shift the sequence by 1 byte = ELLOf
...And it loop until file is ended.

Case Idea of this programm is to decrypt, hack file formats
with no open documentation. You take several file of same format 
and scan them for common sequences. This sequences may be some 
keywords like: property name, and etc.

