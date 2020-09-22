# Distributed-Operating-System-Principles (COP5615) Project 1
  Perfect squares formed by the sums of consecutive squares


#Group members:
  
      Name                UFID
  Shaunak Sompura       9911-2362
  Bharath Shankar       9841-4098
  

#Steps to run
1. Unzip the file and navigate inside the folder
2. Open Terminal
3. Run the following command: 
    dotnet fsi --langversion:preview proj1.fsx 1000000 24
  
    Output: 
        [Prints first number of the sequence that forms a perfect square]
        
        real: <real time> in ms
        user: <user time> in ms
        sys: <sys time> in ms
        Num of Cores Used in the computation
        ration of CPU time to Real Time
        
        
 #Size of work unit for each worker actor
 
 
 
 #Result of running dotnet fsi proj1.fsx 1000000 4
    
    There are no sequences of length k = 4 for n = 1000000
    
 #Running time for n = 1000000 and k = 4
    Real Time: 3800 ms
    CPU Time: 18310 ms
    Num of Cores: 8 Cores Used: 4.818421
 
 
 #Largest Problem solved
 
 N = 10^8 and k = 24
 
9

25

197

304

353

540

856

76

121

1301

2053

3112

3597

5448

8576

12981

20425

30908

35709

54032

84996

128601

202289

306060

353585

534964

841476

1273121

2002557

3029784

3500233

5295700

8329856

12602701

19823373

29991872

34648837

45863965

52422128

82457176

Real Time: 538246 ms
CPU Time: 2844720 ms
Num of Cores: 8 Cores Used: 5.285167

 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
