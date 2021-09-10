# CoinJar API

## How to use the CoinJar API
- Clone the repository to your local machine.
- Open *CoinJar.sln* in Visual Studio and run the project.
- Your browser will open with the API endpoints from where you can Add Coins, Get the Total Balance or Reset the balance.  
- Alternatively, you can use tools like Postman

## Operation
- Each coin type has a different volume calculated according to its size.
- If the volume of all the coins is more than 42 fluid ounces, the API will return with error code 500 "There is no more space in the Jar."
