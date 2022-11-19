# Lookup

This app is a kind of analog of the [RevitLookup](https://github.com/jeremytammik/RevitLookup) but only for the TeklaStructures. 
It's possible to do next actions with it:

1. See all possible names of **fields**, **properties**, **methods** (both private and public).
2. Browse all kinds of **values** of private and public fields and properties.
3. **Get** and **browse values** of private and public **methods**, which don't require setting any parameters.

The code of the program works through the .Net Framework System.Reflection mechanism and gives to a user all information that it's possible to take from the TeklaStructures API.

## Table of Contents (Optional)

- [Installation](#installation)
- [Usage](#usage)
- [Credits](#credits)
- [License](#license)

## Installation

You need to put latest tsep file in a folder **\TeklaStructures\2020.0\Extensions\To be installed** and restart TeklaStructures. After this the application will install to a folder **\Environments\common\extensions** and you will able to use it.

## Usage

1. When your Tekla Structures is running find on "Extensions and macroses" panel **Lookup** application and click twice on it
2. If you selected some elements in a model (or drawing) information about them will appear in the Lookup tabs. Otherwise Lookup will try to get info from the current model (or drawing)
3. Buttons
    3.1. Button **Snoop** allows to get API information for the current selected object. The same action also possible to do with double click on the object you are intersting in.
    3.2. Button **Get selected objects** gathers information about all selected objects and it to the "Objects" list. If nothing is select information will from the current model or drawing
  

## Credits

If anybody wants to join the development - just write me on my email - **karpovich.pavel@gmail.com**

## License

GPL v.3.0
