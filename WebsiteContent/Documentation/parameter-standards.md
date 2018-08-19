# Parameter Standards

To maintain quality control, all OpenRFA shared parameters must follow the guidelines in this documentation. If you are unsure about how to name your parameter or what data type we should assign, take a best guest and the community will help propose suggestions.

## Naming Conventions

In order for your shared parameter to be approved, you must follow our strict naming convention. This specific concatenation is as follows:

[Major][Minor][ModifierA][ModifierB]

Note that not all fields are required for every parameter. For example, [Barcode](http://openrfa.org/a3931ae2-7122-40ec-b283-8b6d5b4be2fa) has only one field and [ApparentPowerInputPrimaryActual](http://openrfa.org/5031db93-bb19-454e-bea4-0f77d60f15e6) actually contains all four.

### Example
AirFlowSupplyActual is a great example of how to use the standard naming convention:

- AirFlow = Major
- Supply = Minor
- Actual = Modifier

## Data Types

For a shared parameter to be approved, it must have the proper [DATA TYPE](https://knowledge.autodesk.com/support/revit-products/learn-explore/caas/CloudHelp/cloudhelp/2015/ENU/Revit-Customize/files/GUID-8136C577-5C69-4694-B703-8BD015697B5B-htm.html) assigned.

For example, if a the intended use for a parameter is to store data regarding HVAC air flow, the Air Flow data type should be used. Avoid incorrect data types such as [TEXT](https://knowledge.autodesk.com/support/revit-products/learn-explore/caas/CloudHelp/cloudhelp/2015/ENU/Revit-Model/files/GUID-94EA2B8E-2C00-4D29-8D5A-C7C6664DE9CE-htm.html) parameters for holding number values. In that case, an [INTEGER](https://knowledge.autodesk.com/support/revit-products/learn-explore/caas/CloudHelp/cloudhelp/2015/ENU/Revit-Model/files/GUID-94EA2B8E-2C00-4D29-8D5A-C7C6664DE9CE-htm.html) or [NUMBER](https://knowledge.autodesk.com/support/revit-products/learn-explore/caas/CloudHelp/cloudhelp/2015/ENU/Revit-Model/files/GUID-94EA2B8E-2C00-4D29-8D5A-C7C6664DE9CE-htm.html) data type should be used.

For more information on using proper data types in Revit, please see [Structured Data](https://pumphousebim.wordpress.com/2017/06/08/structured-data-in-revit/) in Revit by [PumphouseBIM](https://twitter.com/pumphouseBIM).

