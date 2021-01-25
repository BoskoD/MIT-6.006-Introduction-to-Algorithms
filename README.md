# MIT-6.006-Introduction-to-Algorithms

## 1) Algorithmic Thinking, Peak Finding 
https://www.youtube.com/watch?v=HtSuA80QTyo&list=PLUl4u3cNGP61Oq3tWYp6V_F-5jb5L2iHb&index=1

Whether it's finding mountain peaks, peak performance days/points in your daily performance(workouts, running, amount of stuff done)

### What is a Peak
Peak is the point/value that is higher than its surroundings. Therefore we can assume that in [1, 6, 1], the 6 is the peak.

Our definition is going to be exactly this, however we are not looking for the one ultimate peak, but all the peaks we can find. 
Anything that is higher than its neighbors will be a peak for us.
That way we will often find multiple values, as long as they are peaks. In [4,9,2,7,6,3], 9 and 7 are the peaks.





## 2) Models of Computation, Document Distance
https://www.youtube.com/watch?v=Zc54gFhdpLA&list=PLUl4u3cNGP61Oq3tWYp6V_F-5jb5L2iHb&index=2

### What is Document Distance?
Consider that you have two documents containing a huge amount of text in them, be it essays or websites. Now you want to know how similar these documents are, in the sense of: how many words overlap in these documents. Conceptual the algorithm is really simple there’s just a few steps that you’ll have to go through:

Open and read both documents that you are going to compare. Only read words and numbers, skip special characters (spaces, dots, etc..) and convert the words to lower case
Calculate the word frequency in both collections of words, this means how many times each word occur in each document
Compare the frequencies from both computations and calculate the distance


