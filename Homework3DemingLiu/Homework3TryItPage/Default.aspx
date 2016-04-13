<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework3TryItPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TryItPage</h1>
        <p class="lead">This page is to test the four services that I will be making for Homework 3 Part II</p>
        <p class="lead">The theme of these four services is to help people make decisions based on their grocery list</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Service 1 - Sorting Algorithm - Moderate</h2>
            <p>
                The sorting algorithm will be sorting the grocery list in an ascending order</p>
            <p>
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Priority</asp:ListItem>
                    <asp:ListItem>Cost</asp:ListItem>
                    <asp:ListItem>Quantity</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sort List" />
            </p>
            <asp:Table ID="Table2" runat="server" Width="300px">
                <asp:TableHeaderRow runat="server">
                        <asp:TableHeaderCell>Grocery Item</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Priority</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Cost</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Quantity</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div class="col-md-4">
            <h2>Service 2 - Suggestion Algorithm - Moderate</h2>
            <p>
                The suggestion algorithm allows user to 
                submit their grocery list and the algorithm will suggest a new list of what to buy</p>
            <p>
                <asp:Table ID="Table1" runat="server" Width="347px">
                </asp:Table>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Service 3 - Find Nearest Store - Simple</h2>
            <p>
                The service will return to you the address of the closest grocery store based on an address that you provide</p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" Width="343px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Find Nearest Grocery Store" />
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Address of Nearest Grocery Store: "></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Service 4 - Find Gas Prices - Simple</h2>
            <p>
                This service will return the national average gas prices used to calculate the cost of travel</p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
&nbsp;National Gas Prices Average:&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
        </div>

    </div>

</asp:Content>
