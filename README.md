# Converter

This programm finds common byte sequenses in any count of files(2,3..100+)

How its work
Lets take 4 file for example:  

  File name:&emsp;1.txt&emsp;&emsp;&emsp;2.txt&emsp;&emsp;&emsp;&nbsp; 3.txt&emsp;&emsp;&emsp;     4.txt
  
  Content:&emsp;gktidnr&emsp;&ensp;232345r&emsp;&emsp;HELLO3r&emsp;   tHge%EL&emsp;
              &ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;HELLOfe   &ensp;&ensp;fdhtHEL   &ensp;&ensp;&ensp;&nbsp;e2#tstg &emsp;  ftOrfdg&emsp;&emsp;
              &emsp;&emsp;&emsp;&emsp;&ensp;grqwee    &ensp;&ensp;&nbsp;LOngfky   &emsp;&nbsp;&nbsp;&nbsp;$@fav5g   &ensp;&nbsp;HELLOgt
              
Program convert 1st file into byte array, enumerate 1 file by bytes
lets see step by step:
We want seek common sequence lenght = 5 word

1 step:  
&emsp;1.txt => sequence 5 word = qktid  
2 step:  
&emsp;seek for qktid in 2.txt, 3.txt, 4.txt  
3 step:  
&emsp;there no such sequence (qktid) in other file  
4 step:  
&emsp;1.txt => shift the sequence by 1 byte = ktidn  
5 step  
&emsp;seek for ktidn in 2.txt, 3.txt, 4.txt  
6 step:
&emsp;there no such sequence (ktidn) in other file  
7 step:  
&emsp;1.txt => shift the sequence by 1 byte = tidnr  
8 step  
&emsp;seek for tidnr in 2.txt, 3.txt, 4.txt  
9 step:  
&emsp;there no such sequence (tidnr) in other file
  
....and so on till sequence HELLO....

10 step:  
&emsp;1.txt => shift the sequence by 1 byte = HELLO  
11 step:  
&emsp;seek for qktid in 2.txt, 3.txt, 4.txt  
12 step:  
&emsp;Found sequence in every file  
13 step:  
&emsp;Write sequence in outlog file  
14 step  
&emsp;1.txt => shift the sequence by 1 byte = ELLOf  
...And it loop until file is ended.

Case Idea of this programm is to decrypt, hack file formats
with no open documentation. You take several file of same format 
and scan them for common sequences. This sequences may be some 
keywords like: property name, and etc.

