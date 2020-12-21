using lab4_films.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_films
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EFDbcontext context = new EFDbcontext();
            if (comboBox1.SelectedIndex.Equals(0))
            {

                context.Films.Load();
                dataGridView1.DataSource = context.Films.Local.ToBindingList();

            }
            if (comboBox1.SelectedIndex.Equals(1))
            {

                context.Actors.Load();
                dataGridView1.DataSource = context.Actors.Local.ToBindingList();

            }
            if (comboBox1.SelectedIndex.Equals(2))
            {

                context.Genres.Load();
                dataGridView1.DataSource = context.Genres.Local.ToBindingList();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

                string name = textBox1.Text;
                int age = Convert.ToInt32(textBox2.Text);
                string nationality = textBox3.Text;
                Actor actor = new Actor();
                var results = new List<ValidationResult>();
                var context = new ValidationContext(actor);
                if (!Validator.TryValidateObject(actor, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new EFDbcontext())
            {
                var actor = context.Actors.Find(2);

                using (var cotextDB = new EFDbcontext())
                {
                    cotextDB.Database.ExecuteSqlCommand("UPDATE Actors SET name = name + '_DB' WHERE actor_id ='2'");
                }

                actor.name = actor.name + "_Memory";

                string value = context.Entry(actor).Property(m => m.name).OriginalValue;
                textBox4.Text = string.Format("{0}", value);

                value = context.Entry(actor).Property(m => m.name).CurrentValue;
                textBox5.Text = string.Format("{0}", value);

                value = context.Entry(actor).GetDatabaseValues().GetValue<string>("name");
                textBox6.Text = string.Format("{0}", value);

            }



        
        }
    }
}
