using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarSite
{
    public partial class CarSite : System.Web.UI.Page
    {
        private List<Producer> producers;
        private List<Extra> extras;
        private List<string> engineTypes;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.InitData();

            if (!IsPostBack)
            {
                this.DropDownListProducer.DataSource = producers;
                this.DropDownListProducer.DataBind();

                this.DropDownListModels.DataSource = this.producers.First().Models;
                this.DropDownListModels.DataBind();

                this.CheckBoxListExtras.DataSource = this.extras;
                this.CheckBoxListExtras.DataBind();

                this.RadioButtonListEngines.DataSource = this.engineTypes;
                this.RadioButtonListEngines.DataBind();
            }
        }

        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProducer = this.DropDownListProducer.SelectedValue;

            var currentProducer = this.producers.FirstOrDefault(p => p.Name == selectedProducer);

            this.DropDownListModels.DataSource = currentProducer.Models;
            this.DropDownListModels.DataBind();
        }

        private void InitData()
        {
            List<Model> mercedesModels = new List<Model>
            {
                new Model("A200"),
                new Model("B200"),
                new Model("C200"),
                new Model("S300")
            };

            List<Model> bmwModels = new List<Model>
            {
                new Model("320"),
                new Model("M6"),
                new Model("Z3")
            };

            List<Model> audiModels = new List<Model>
            {
                new Model("A3"),
                new Model("A6"),
                new Model("A7"),
                new Model("Q7")
            };

            List<Model> citroenModels = new List<Model>
            {
                new Model("C3"),
                new Model("C4"),
                new Model("C6"),
                new Model("C7")
            };

            List<Model> nissanModels = new List<Model>
            {
                new Model("Primera"),
                new Model("Almera"),
                new Model("Juke"),
                new Model("Quashquai")
            };

            this.producers = new List<Producer> 
            {
                new Producer("Mercedes", mercedesModels),
                new Producer("BMW", bmwModels),
                new Producer("Audi", audiModels),
                new Producer("Citroen", citroenModels),
                new Producer("Nissan", nissanModels)
            };

            this.extras = new List<Extra>
            {
                new Extra("Four wheel drive"),
                new Extra("Automatic transmission"),
                new Extra("Climatronic"),
                new Extra("Parktronic")
            };

            this.engineTypes = new List<string>
            {
              "Diesel",
              "Benzin",
              "Electric",
              "Hybrid"
            };
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            StringBuilder submittedText = new StringBuilder();

            var producer = this.DropDownListProducer.SelectedValue;
            var model = this.DropDownListModels.SelectedValue;
            List<string> extras = new List<string>();

            for (int i = 0; i < CheckBoxListExtras.Items.Count; i++)
            {
                if (CheckBoxListExtras.Items[i].Selected)
                {
                    string extra = CheckBoxListExtras.Items[i].Value;
                    extras.Add(extra);
                }
            }

            var engineType = this.RadioButtonListEngines.SelectedValue;

            submittedText.Append("<h2>Submitted info:</h2>");
            submittedText.Append("<br />");
            submittedText.Append(string.Format("<strong>Producer: </strong><span>{0}</span>", producer));
            submittedText.Append("<br />");
            submittedText.Append(string.Format("<strong>Model: </strong><span>{0}</span>", model));
            submittedText.Append("<br />");
            submittedText.Append("<strong>Extras: </strong>");
            submittedText.Append("<ul>");

            foreach (var extra in extras)
            {
                submittedText.Append(string.Format("<li>{0}</li>", extra));
            }

            submittedText.Append("</ul>");
            submittedText.Append("<br />");
            submittedText.Append(string.Format("<strong>Engine type: </strong><span>{0}</span>", engineType));

            this.submittedInfo.Text = submittedText.ToString();
        }
    }
}