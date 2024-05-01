# Lookup

<img src="https://github.com/karpovichpv/Lookup/blob/master/Docs/Screenshots/Lookup_for_TeklaStructures.png" alt="Lookup. Main window" width="700"/>

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

<img src="https://github.com/karpovichpv/Lookup/blob/master/Docs/Screenshots/Lookup_GIF_usage.gif" alt="Lookup. Main window" width="700"/>

1. When your Tekla Structures is running find on "Applications & components" panel **Lookup** application and click twice on it
2. If you selected some elements in a model (or drawing) information about them will appear in the Lookup tabs. Otherwise Lookup will try to get info from the current model (or drawing)
3. Buttons
    - button **Snoop** allows to get API information for the current selected object. The same action also possible to do with double click on the object you are intersting in.
    - button **Get selected objects** gathers information about all selected objects and it to the "Objects" list. If nothing is select information will from the current model or drawing
4. In the left list you possibly will see that some elements are **in bold** that means that you by double mouse click can "walk down" and watch properties for this element.

## Roadmap

- [ ] Reading user properties from the drawing for parts
- [ ] Writting user properties to the elements
- [ ] Getting report properties for the certain parts (list of properties is getting from .lst file)


## Credits

If anybody wants to join the development - just write me on my email - **karpovich.pavel@gmail.com**

## License

MIT License
