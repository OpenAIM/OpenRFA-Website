* How much does OpenRFA cost?
* What is the difference between "Actual" and "Design" parameters?

### How much does OpenRFA cost?
* OpenRFA is and always will be 100% free.

<a href="/faq-page#faq-top" title="Go back to the top of the page." class="active">Back to Top</a>

### What is the difference between "Actual" and "Design" parameters?
> _There are several parameters that begin with Actual and Design in their names. What is the intended use for each?_

* ["Actual" parameters](http://openrfa.org/shared-parameters/approved?title=actual&field_data_category_tid=All&field_data_type_tid=All&field_group_tid=All "Collaborative master shared parameters for Revit - Actual calculated parameters") should be used to store data from calculated values from analytical tools or for bringing in operational data from a BMS system. For example, if we were looking at the airflow for a CRAC unit, the unit is designed to run at 10,000 CFM, but after calculating the load in an energy model its "Actual" airflow value might equal 6,300 CFM and would be stored in the [ActualSupplyAirflow](http://openrfa.org/82403120-78c4-43cd-8a0a-60aa1f8e8bf3 "Collaborative master shared parameters for Revit - Actual calculated supply air flow parameter") parameter. Another example is storing the trended data for the average or instantaneous value from the BMS.

* ["Design" parameters](http://openrfa.org/shared-parameters/approved?title=design&amp;field_data_category_tid=All&amp;field_data_type_tid=All&amp;field_group_tid=All "Collaborative master shared parameters for Revit - Design parameters") are intended to be used for designing systems. For example, you would add [DesignSupplyAirflow](http://openrfa.org/6dd3aa10-8f89-427d-932a-3234aff88266 "Collaborative master shared parameters for Revit - Designed supply are flow parameter") in your families to annotate your views or size ductwork. These are also commonly referred to as 'basis of design' values. 

<a href="/faq-page#faq-top" title="Go back to the top of the page." class="active">Back to Top</a>
