<%@ Page Title="CSE 445 Homework 3 Try It" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445Homework3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        The Calendar Services Try It Page:</p>
<p>
        Service1: The CreateCalendar Service has 3 methods: create calendar, display calendar, and add event. This is a SOAP web service. </p>
    <p>
        The create calendar button invokes the first 2 methods. The add event button invokes the third. Calendar is displayed at bottom)</p>
<p>
        Start Date<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create Calendar" />
</p>
<p>
        &nbsp;</p>
<p>
        Name<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        Description<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        Date<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        Start Time (00:00XX)<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        End Time(00:00XX)<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Event" />
</p>
<p>
        &nbsp;</p>
<p>
        Service 2: The EditCalendar Service has one method and takes in whether you want to delete&nbsp; an event or edit it by time and date. </p>
    <p>
        This is a SOAP web service. The Edit Event button invokes this method. (Calendar is displayed at bottom)</p>
<p>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Edit Event By Time and Date</asp:ListItem>
            <asp:ListItem>Delete Event</asp:ListItem>
        </asp:DropDownList>
</p>
<p>
        Date<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        Start Time<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        End Time<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        Name<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        Description<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Edit Event" />
</p>
<p>
        &nbsp;</p>
<p>
        Service 3: The AvailableTime Service calculates the available time a given number of dayss and years assuming approximately </p>
    <p>
        15 awake hours per day and 365 days in a year. This is a RESTful web service. </p>
    <p>
        The Calculate Free Time button invokes this service.</p>
<p>
        Days:<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
        Years:<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Calculate Awake Time" />
        <asp:Label ID="Label1" runat="server" Text="Awake Time (hours):"></asp:Label>
</p>
<p>
        &nbsp;</p>
<p>
        Service 4: The WeatherService converts temperatures from C to F or F to C This is a RESTful web service. </p>
    <p>
        The Get Temperature Conversion button invokes this service.</p>
<p>
        Temp<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
        Unit (C or F):<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Get Temperature Conversion" />
        <asp:Label ID="Label2" runat="server" Text="Temperature:"></asp:Label>
</p>
<p>
        &nbsp;</p>
<p>
        Calendar Display (date/name/description):</p>
<p>
        <asp:Label ID="Label4" runat="server" Text="Calendar"></asp:Label>
</p>
<p>
        <asp:Label ID="Label5" runat="server" Text="Calendar"></asp:Label>
    </p>
<p>
        <asp:Label ID="Label6" runat="server" Text="Calendar"></asp:Label>
    </p>
<p>
        <asp:Label ID="Label7" runat="server" Text="Calendar"></asp:Label>
    </p>
<p>
        <asp:Label ID="Label8" runat="server" Text="Calendar"></asp:Label>
    </p>
<p>
        <asp:Label ID="Label9" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label10" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label14" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label15" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label16" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label17" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label18" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label19" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label20" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label21" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label22" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label23" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label24" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label25" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label26" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label27" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label28" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label29" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label30" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label31" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label32" runat="server" Text="Calendar"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label33" runat="server" Text="Calendar"></asp:Label>
    </p>
<p>
        <asp:Label ID="Label34" runat="server" Text="Calendar"></asp:Label>
    &nbsp;String</p>
<p>
        <asp:Label ID="Label35" runat="server" Visible="False"></asp:Label>
    </p>

</asp:Content>
