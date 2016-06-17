<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameTracker_c.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <bs3:Jumbotron runat="server" ID="Jumbotron1">
        <BodyContent>
<!--Author: Naga Rimmalapudi and Chandra Reddy 
    Stud #: 200277598 & 200275643
    Date: June 10th, 2016
    Description: This is our home page. This page display the games tracked -->
            <h1>Welcome to StatTastic!</h1>
        </BodyContent>
    </bs3:Jumbotron>
    <div class="container">
        <% if (Session["userName"] != null)
            { %>
        <div style="padding: 20px"><a href="CreateGamePage.aspx" class="jumbotron" style="padding: 13px;"><i class="fa fa-plus fa-lg"> Add Game</i></a></div>
        <% } %>

        <div class="row">
            <div class="jumbotron">
                <div class="span4 collapse-group">
                    <a class="btn btn-collapse" href="#" role="button">
                        <img src="Assets/glyphicons_free/glyphicons/png/glyphicons-330-soccer-ball.png" />
                        Soccer &raquo;</a>
                    <div class="collapse">
                        <p>Have a soccer game displayed here with Team Name, scores, attendances and stadium</p>
                        <!-- Next and Previous Button Goes here -->
                        <div class="row">
                            <div class="col-xs-4 col-md-4">
                                Previous Button
                            </div>
                            <div class="col-xs-4 col-md-4">
                                Current week 
                            </div> 
                        <div class="col-xs-4 col-md-4">
                                Next Button
                            </div>     
                        </div>
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
            </div>
        </div>
        <div class="row">
            <div class="jumbotron">
                <div class="span4 collapse-group">
                    <a class="btn btn-collapse" href="#" role="button">
                        <img src="Assets/glyphicons_free/glyphicons/png/glyphicons-463-basketball.png" />
                        Basketball &raquo;</a>
                    <p class="collapse">Have a Basketball game displayed here with Team Name, scores, attendances and stadium</p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="jumbotron">
                <div class="span4 collapse-group">
                    <a class="btn btn-collapse" href="#" role="button">
                        <img src="Assets/glyphicons_free/glyphicons/png/glyphicons-438-hockey.png" />
                        Hockey &raquo;</a>
                    <p class="collapse">Have a Hockey game displayed here with Team Name, scores, attendances and stadium</p>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="jumbotron">
                <div class="span4 collapse-group">
                    <a class="btn btn-collapse" href="#" role="button">
                        <img src="Assets/glyphicons_free/glyphicons/png/glyphicons-312-baseball.png" />
                        Baseball &raquo;</a>
                    <p class="collapse">Have a Baseball game displayed here with Team Name, scores, attendances and stadium</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>