Maximun CityTraffic description 

 

For this challenge you will be finding the maximum traffic that will enter a node. 


Have the function CityTraffic(strArr) read strArr which will be a representation of an undirected graph in a form similar to an adjacency list. 

Each element in the input will contain an integer which will represent the population for that city, and then that will be followed by a comma separated list of its neighboring cities and their populations (these will be separated by a colon).  

For example: strArr may be 

["1:[5]", "4:[5]", "3:[5]", "5:[1,4,3,2]", "2:[5,15,7]", "7:[2,8]", "8:[7,38]", "15:[2]", "38:[8]"].  

This unricted graph has been shown in the following picture.  

Each node represents the population of that city and each edge represents a road to that city. Your goal is to determine the maximum  

traffic that would occur via a single road if everyone decided to go to that city. For example: if every single person in all the cities decided to go to city 7, then via the right road (Road 8) the number of people coming in would be (8 + 38) = 46.  

If all the cities in the left side of city 7 decided to go to there (7) via the left road (road 2), the number of people coming in would be (2 + 15 + 1 + 3 + 4 + 5) = 30. So  

the maximum traffic coming into the city 7 would be 46 because the maximum value of (30, 46) = 46. 

Your program should determine the maximum traffic for every single city and return the answers in a comma separated string in the 

format: city:max_traffic,city:max_traffic,... The cities should be outputted in sorted order by the city number. For the above example,  

the output would therefore be: 

1:60,2:53,3:60,4:60,5:55,7:46,8:38,15:55,38:32 

The cities will all be unique positive integers and there 

will not be any cycles in the graph. There will always be at least 2 cities in the graph 

 

 

((Obs! If all cities want to go to one node (city) without taking the maz of neighbers then the result shall be: 

 1:82,2:81,3:80,4:79,5:78,7:76,8:75,15:68,38:45.) 
