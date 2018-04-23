# How to get the first visible row when scrolling


<p>You should get a DataPresenter. This dependency object supports the IScrollInfo interface. This interface provides the VerticalOffcet property. In fact, this property is a VisibleIndex for the row. Use the GridControl.GetRowHandleByVisibleIndex method to get the first visible row handle.</p>

<br/>


