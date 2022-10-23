# Lookup

This app is a kind of analog of the [RevitLookup](https://github.com/jeremytammik/RevitLookup) but only for the TeklaStructures. 
It's possible to do next actions with it:

1. See all possible names of **fields**, **properties**, **methods** (both private and public).
2. Browse all kinds of **values** of private and public fields and properties.
3. **Get** and **browse values** of private and public **methods**, which don't require setting any parameters.

The code of the program works through the .Net Framework System.Reflection mechanism and gives to a user all information that it's possible to take from the TeklaStructures API.
