<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tracks.aspx.cs" Inherits="Notch.WebForms.Tracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #content {
            margin-top: 50px;
        }
    </style>

    <div id="content">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-12">
                        <h4>All tracks</h4>
                    </div>
                </div>
            </div>
            <asp:GridView ID="trackList" runat="server" AutoGenerateColumns="false"
                DataKeyNames="Id" CellPadding="10" CellSpacing="0"
                ShowFooter="true"
                CssClass="table table-striped table-bordered text-center"
                OnRowCommand="trackList_RowCommand"
                OnRowCancelingEdit="trackList_RowCancelingEdit"
                OnRowDeleting="trackList_RowDeleting"
                OnRowEditing="trackList_RowEditing"
                OnRowUpdating="trackList_RowUpdating">

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>Track Name</HeaderTemplate>
                        <ItemTemplate><%#Eval("Name") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%#Bind("Name") %>' />
                            <asp:RequiredFieldValidator ID="rfCPEdit" runat="server" ForeColor="Red" ErrorMessage="*"
                                Display="Dynamic" ValidationGroup="edit" ControlToValidate="txtName">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCP" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtName">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>BPM</HeaderTemplate>
                        <ItemTemplate><%#Eval("BPM") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBPM" runat="server" Text='<%#Bind("BPM") %>' />
                            <asp:RequiredFieldValidator ID="rfCNEdit" runat="server" ErrorMessage="*"
                                Display="Dynamic" ForeColor="Red" ValidationGroup="edit" ControlToValidate="txtBPM">Required</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBPM" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfCN" runat="server" ErrorMessage="*"
                                ForeColor="Red" Display="Dynamic" ValidationGroup="Add" ControlToValidate="txtBPM">Required</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" CssClass="btn btn-info btn-sm">Edit</asp:LinkButton>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you confirm?')">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update" CssClass="btn btn-info btn-sm" ValidationGroup="edit">Update</asp:LinkButton>
                            <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel" CssClass="btn btn-info btn-sm">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnInsert" runat="server" Text="Save" CommandName="Insert" CssClass="btn btn-success btn-sm" ValidationGroup="Add" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>