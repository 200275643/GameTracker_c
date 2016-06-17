<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameTracker_c.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <% if (Session["userName"] != null)
            { %>
        <div style="padding: 20px"><a href="CreateGamePage.aspx" class="jumbotron" style="padding: 13px;"><i class="fa fa-plus fa-lg"> Add Game</i></a></div>
        <% } %>

        <div class="row">
            <div class="col-xs-12 col-md-4">
                <div class="jumbotron" > 
                    <a class="btn btn-collapse" href="#" role="button">
                       
                       Soccer &raquo;</a>
                    
                        <p>Game Stats</p>
                       <div class="text-center">
                            <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                                ID="SoccerGamesGridView" AutoGenerateColumns="false" DataKeyNames="Id"
                                OnRowDeleting="SoccerGamesGridView_RowDeleting" AllowPaging ="true"
                                PageSize="4" OnPageIndexChanging="SoccerGamesGridView_PageIndexChanging"
                                AllowSorting="false">
                                <Columns>
                                    <asp:BoundField DataField="hometeam" HeaderText="Home Team" Visible="true" />
                                    <asp:BoundField DataField="hometeampoints" HeaderText="Home Team Points" Visible="true" />
                                    <asp:TemplateField HeaderText="VS"><ItemTemplate><label >VS</label></ItemTemplate></asp:TemplateField>
                                    <asp:BoundField DataField="awayteampoints" HeaderText="Away Team Points" Visible="true" />
                                    <asp:BoundField DataField="awayteam" HeaderText="Away Team" Visible="true" />
                                    <asp:BoundField DataField="attendance" HeaderText="Attendance" Visible="true" />
                                    <asp:BoundField DataField="venue" HeaderText="Venue" Visible="true" />
                                    <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true"
                            ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                                    
                                </Columns>
                            </asp:GridView>
                        </div>   
                        </div>
                    </div>
                
            
       <div class="col-xs-12 col-md-4">
            <div class="jumbotron"> 
                    <a class="btn btn-collapse" href="#" role="button">
                        
                        Tennis &raquo;</a>
                     <p>Game Stats</p>
                </div>
        </div>
            </div>
<div class="row">
        <div class="col-xs-12 col-md-4">
           <div class="jumbotron">  
                    <a class="btn btn-collapse" href="#" role="button">
                        
                       Cricket &raquo;</a>
                     <p>Game Stats</p>
           </div>     
        </div>
        <div class="col-xs-12 col-md-4">
          <div class="jumbotron">  
                    <a class="btn btn-collapse" href="#" role="button">
                        
                        Golf &raquo;</a>
                     <p>Game Stats</p>
                 </div>
            </div>
            </div>
    </div>
</asp:Content>