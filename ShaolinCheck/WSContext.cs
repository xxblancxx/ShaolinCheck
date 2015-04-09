﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShaolinCheck
{
    class WSContext
    {
        private HttpClientHandler handler;
        public const string ServerUrl = "http://localhost:17819/api/";
        public async Task<List<Club>> GetAllClubs()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("clubs");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var clublist = await response.Content.ReadAsAsync<IEnumerable<Club>>();
                // var will give you a variable of type IEnumerable.
                return clublist.ToList();
            }
        }

        public async Task<ObservableCollection<Team>> GetAllTeams()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Teams");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var teamlist = await response.Content.ReadAsAsync<ObservableCollection<Team>>();
                // var will give you a variable of type IEnumerable.
                return teamlist;
            }
        }

        public async Task<ObservableCollection<Student>> GetAllStudents()
        {
            handler = new HttpClientHandler();
            //Creates a new HttpClientHandler.
            handler.UseDefaultCredentials = true;
            //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                var task = client.GetAsync("Students");
                // var means the compiler will determine the explicit type of the variable, based on usage. this would give you a variable of type Client.
                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                // check for response code (if response is not 200 throw exception)
                var studentlist = await response.Content.ReadAsAsync<ObservableCollection<Student>>();
                // var will give you a variable of type IEnumerable.
                return studentlist;
            }
        }

    }
}
