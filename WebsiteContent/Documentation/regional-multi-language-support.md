# Regional & Multi-Language Support

The OpenRFA shared parameters support multiple languages. Although the parameter names will differ from language to language, Revit classifies the data held within each parameter as the same data set. For example, if you load in an exhaust fan family from a Spanish vendor into your English Revit project, you will still have the ability to schedule the family with other families that use the English version of the parameter.

To help contribute with translations, simply input the alternative language or region-specific name when editing or creating a shared parameter. So far, we only have support for Spanish translations, but if you have a suggestion for other regional versions of a parameter, please [contact OpenRFA](http://openrfa.org/contact).

Once a parameter has a translation override, you can go to that language/regional overridden list to download the appropriate definitions file. For an example, refer to the Spanish translated parameters: [Shared Parameters (ESP)](http://openrfa.org/shared-parameters/approved/esp).

## Example

To demonstrate multi-language and regional support, we have a Revit project which has an exhaust fan (Mechanical Equipment category) loaded in.

![Multi-language and regional shared parameters for Revit family](http://openrfa.org/sites/default/files/2017-06-14%2009_15_29-3D%20View_%20View%201%20-%20Exhaust%20Centrifugal%20Fan%20-%20ESP.rfa.png "Multi-language and regional shared parameters for Revit family")

Two English parameters are loaded into the family: AirFlowExhaustActual and AirFlowExhaustDesign.

![Working with multi-language / regional shared parameters in Revit families](http://openrfa.org/sites/default/files/2017-06-14%2009_18_05-Family%20Types.png "Working with multi-language / regional shared parameters in Revit families")

Now, we load the family into a Revit project and build a simple schedule to display the data within the English version of the family.

Now we will take a second family, and load the [Spanish version of the same shared parameters](http://openrfa.org/shared-parameters/approved/esp) from the previous step. Note the Shared parameter file name contains "ESP" in parenthesis, which denotes the language overrides.

![Multi-language / regional master shared parameters for Revit.](http://openrfa.org/sites/default/files/2017-06-14%2009_19_12-Edit%20Shared%20Parameters.png "Multi-language / regional master shared parameters for Revit.")

If a shared parameter does not have a regional translation assigned, the default English name is used in the definitions file.

Finally, load the Spanish exhaust fan family into your project.
Notice that the schedule has been populated with the added family and the values from the Spanish version of the parameters is in the same data set (the same schedule column) as the English version.

![Multi-language revit families](http://openrfa.org/sites/default/files/2017-06-14%2009_28_13-Autodesk%20Revit%202017.2%20-%20%5B3D%20View_%20Fans%20-%20Project1%5D.png "Multi-language Revit families")
