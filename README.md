# Lookup

<img src="https://github.com/karpovichpv/Lookup/assets/66169282/e63a1c4a-e216-4aa0-bd26-dc4247b62d21" alt="The Lookup for the TeklaStructures. The main window" width="700"/>

This app is a kind of analog of the [RevitLookup](https://github.com/jeremytammik/RevitLookup) but only for the TeklaStructures. 
It's possible to do next actions for a selected element with it:

1. See all possible names of **fields**, **properties**, **methods** (both private and public)
2. Browse all kinds of **values** of private and public fields and properties
3. **Get** and **browse values** of private and public **methods**, which don't require setting any parameters
4. View user properties
5. Read/Write dynamic string properties

The code of the program works through the .Net Framework System.Reflection mechanism and gives to a user all information that it's possible to take from the TeklaStructures API.

## Table of Contents (Optional)

- [Installation](#installation)
- [Usage](#usage)
- [Credits](#credits)
- [License](#license)

## Installation

You need to put latest tsep file in a folder ``\TeklaStructures\202*.0\Extensions\To be installed`` and restart TeklaStructures. After this the application will be installed to the folder **\Environments\common\extensions**.

## Usage

<img src="https://github.com/karpovichpv/Lookup/blob/master/Docs/Screenshots/Lookup_GIF_usage.gif" alt="Lookup. Main window" width="700"/>

1. When your Tekla Structures is running find on the "Applications & components" panel the **Lookup** application and click twice on it
2. If you selected some elements in a model (or drawing) the information about them will appear on the Lookup tabs. Otherwise Lookup will try to get the info from the current model (or drawing)
3. The **Get selected objects** button gathers information about all selected objects and it to the "Objects" list. If nothing is select information will from the current model or drawing
4. In the left list you possibly will see that some elements are **in bold** that means that you by double mouse click can "walk down" and watch properties for this sub element - just try it and you understand how it's work
5. On the User-properties tab it's possible to observe UDA for model, drawing objects or for the ProjectInfo
6. On the Dynamic String Properties tab you can read and write dynamic string properties for ModelObjects or a ProjectInfo. It's important to understand that the TeklaStructures API cannot give the list of used DynamicStringProperties names for the selected element unlike as for an ordinary UDA. That's why you need type you own names which will be stored in the DynamicStringProperties.lkp file near the Lookup.exe file. It's prevent for typing names again. Changes in the TeklaStructures database will apear only after you will push the Enter on your keyboard

## Roadmap

- [ ] Reading user properties from the drawing for parts
- [ ] Writting user properties to the elements
- [ ] Getting report properties for the certain parts (list of properties is getting from .lst file)


## Credits

If anybody wants to join the development - just write me on my email - **karpovich.pavel@gmail.com**

## License

MIT License
