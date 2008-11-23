<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCustomer.aspx.cs" Inherits="NewCustomer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PersonID" DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="PersonID" HeaderText="PersonID" 
                InsertVisible="False" ReadOnly="True" SortExpression="PersonID" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="AddressLine1" HeaderText="AddressLine1" 
                SortExpression="AddressLine1" />
            <asp:BoundField DataField="AddressLine2" HeaderText="AddressLine2" 
                SortExpression="AddressLine2" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:BoundField DataField="TaxCode" HeaderText="TaxCode" 
                SortExpression="TaxCode" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:studiovet2ConnectionString1 %>" 
        DeleteCommand="DELETE FROM [Person] WHERE [PersonID] = @PersonID" 
        InsertCommand="INSERT INTO [Person] ([FirstName], [LastName], [AddressLine1], [AddressLine2], [City], [TaxCode]) VALUES (@FirstName, @LastName, @AddressLine1, @AddressLine2, @City, @TaxCode)" 
        ProviderName="<%$ ConnectionStrings:studiovet2ConnectionString1.ProviderName %>" 
        SelectCommand="SELECT [PersonID], [FirstName], [LastName], [AddressLine1], [AddressLine2], [City], [TaxCode] FROM [Person]" 
        UpdateCommand="UPDATE [Person] SET [FirstName] = @FirstName, [LastName] = @LastName, [AddressLine1] = @AddressLine1, [AddressLine2] = @AddressLine2, [City] = @City, [TaxCode] = @TaxCode WHERE [PersonID] = @PersonID">
        <DeleteParameters>
            <asp:Parameter Name="PersonID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="AddressLine1" Type="String" />
            <asp:Parameter Name="AddressLine2" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="TaxCode" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FirstName" Type="String" />
            <asp:Parameter Name="LastName" Type="String" />
            <asp:Parameter Name="AddressLine1" Type="String" />
            <asp:Parameter Name="AddressLine2" Type="String" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="TaxCode" Type="String" />
            <asp:Parameter Name="PersonID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <p>
    </p>
    
</asp:Content>

