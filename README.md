# Distributed-Operating-System-Principles (COP5615) Project 1


#Group members:

| Name            |       
|-----------------|
| Shaunak Sompura |  
| Bharat Shankar  | 


     Problem definition: Given N and k, find all k consecutive numbers starting at 1 and upto N such that the sum of squares is itself a perfect square.

    Approach: The solution to this problem is achieved using the actor facility in F# and Akka.NET. Multiple child actors are spawned and assigned computational tasks using a single parent actor. This actor model decreases time taken to compute solution by carrying out tasks in parallel.


#Steps to run
1. Unzip the file and navigate inside the folder
2. Open Terminal
3. Run the following command: 
    dotnet fsi --langversion:preview proj1.fsx 1000000 24
  
    Output: 
        [Prints first number of the sequence that forms a perfect square]
               
        Real time: <real time> in ms
        CPU time: <cpu time> in ms
        Cores Used : <cores used in computation>
        (ratio of CPU time to Real Time)
        
        
 #Size of work unit for each worker actor
 
 
    • The work unit considered was k where a sequence of numbers of size k was given to each actor.
    • The actor then squares each of those values of size k and adds it up.
    • Another approach was to simultaneously square all the values from 1 to N by assigning it to actors and then sum up each sequence of size k parallelly.
    • But this would take more time and space, since the boss would need to wait till all the squares are computed by workers and also needs space to store it.

    • For an input of 1000000 it was found that dividing the work to 1000 actors where each actor received 1000 work units, used the most cores delivering the best performance.
    • But when the input N<1000 we create only N actors and assigned 1 work unit for each actor.
    • When 10,000 actors were spawned it was found to be more cumbersome to maintain this number of actors than perform the squaring.



For an input N=1000000 and k=24

| No. of Actors | Work Unit Received by each actor | Cores used |
|---------------|----------------------------------|------------|
| 1000          | 1000                             | 4.84       |
| 10000         | 100                              | 4.59       |
| 100000        | 10                               | 4.08       |


 
 #Result of running dotnet fsi proj1.fsx 1000000 4
    
    There are no sequences of length k = 4 for n = 1000000
    
 #Running time for n = 1000000 and k = 4
   
    Real Time: 3800 ms
    CPU Time: 18310 ms
    Num of Cores: 8 Cores Used: 4.818421
 
 ![](dosproj1.png)
 
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

 
 Note: Please refer Readme.pdf for screenshots
 
 
 
 
 
 
 
 
 
 
 
 
 
 
