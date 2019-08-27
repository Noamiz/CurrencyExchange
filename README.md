# CurrencyExchange
#### Currency exchange rates project - Noam Mizrachi
Note: full documentation can be found in the solution at each class.
1. In this project I decided to save and read the data from a file. (The files will be created in bin\Debug folder).
I chose to save and read the data to/ from a file because in this project there was no need for saving previous currency exchange rates values, but to override the old values each time. In case saving previous values was required for some calculations and statistics, I would have use a database to save the values each time and not override them.
2. In order to build distributed system as possible, I devided it to a modle-view-controller design pattern (MVC). The data structures are independent of the user interface and controller.
3. BONUS: In order to show that I support a situation where there was a problem with the original data services, I implemented 2 different currency exchange rates APIs from 2 different websites: 1. https://fixer.io, 2. https://openexchangerates.org/. 
I created an Interface called FinanceFetcher.cs for implement each API (classes OpenExRatesFinanceFetcher.cs for OpenExchangeRates API and FixerFinanceFetcher.cs for fixer's API) with the same methodes, properties and rules.
This way we are having an option for easly implementing various APIs or new APIs if needed.
