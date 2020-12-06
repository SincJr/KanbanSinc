using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemacTeste
{
    public partial class Form1 : Form
    {
        private List<ListBox> listinha = new List<ListBox>();
        public object lb_item = null;
        public object coisa = null;
        private ListBox antes = new ListBox();
        private string[] prioridade =  { "Tranquilo", "Importante", "Urgente"};
        private int contador = 0;

        public Form1()
        {
            InitializeComponent();
            
            listinha.Add(listBox1);
            listinha.Add(listBox2);
            listinha.Add(listBox3);

            
            
        }

        private void ex_Click(object sender, EventArgs e)
        {
            
            foreach (ListBox caixa in listinha)
            {
                if (caixa.SelectedIndex != -1)
                {
                    caixa.Items.Remove(caixa.SelectedItem);
                }
            }
            
        }


        private void Mudar(ListBox irPara)
        {
            foreach (ListBox caixa in listinha)
            {
                if (caixa.SelectedIndex != -1 && !irPara.Items.Contains(caixa.SelectedItem.ToString()))
                {
                    irPara.Items.Add(caixa.SelectedItem);
                    caixa.Items.Remove(caixa.SelectedItem);

                }
            }

        }

        private void p_Click(object sender, EventArgs e)
        {
            this.Mudar(listBox1);
            
        }

        private void e_Click(object sender, EventArgs e)
        {
            this.Mudar(listBox2);
        }

        private void c_Click(object sender, EventArgs e)
        {
            this.Mudar(listBox3);
        }


        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = -1;
            listBox3.SelectedIndex = -1;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            listBox2.SelectedIndex = -1;
            listBox3.SelectedIndex = -1;
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            listBox2.SelectedIndex = -1;
            listBox1.SelectedIndex = -1;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            MouseEventArgs a = new MouseEventArgs(MouseButtons.Left, 1,0,0,0);
            
            
            if(e.KeyCode == Keys.Enter)
                button5_Click(sender, a);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                pictureBox1.BackgroundImage = SemacTeste.Properties.Resources.sinc;
                label1.ForeColor = Color.Black;
                this.BackColor = Color.White;
                checkBox1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
            }
            else
            {
                pictureBox1.BackgroundImage = SemacTeste.Properties.Resources.sinc_positivo2;
                label1.ForeColor = Color.White;
                this.BackColor = Color.FromArgb(139,9,36);
                checkBox1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
            }
        }
        private void listBox1_DragLeave(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;

            lb_item = lb.SelectedItem;

            
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (lb_item != null)
            {
                listBox1.Items.Add(lb_item);
                
                lb_item = null;
            }
            Console.WriteLine("DragEnter!");
            e.Effect = DragDropEffects.Copy;

        }


        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lb_item = null;

            if (listBox1.Items.Count == 0 || listBox1.SelectedIndex == -1)
            {
                return;
            }

            int index = listBox1.IndexFromPoint(e.X, e.Y);
            string s = listBox1.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            ListBox recebido = sender as ListBox;
            foreach (var list1 in listinha)
            {
                foreach (var list2 in listinha)
                {
                    foreach (var item1 in list1.Items)
                    {
                        int cont = 0;

                        foreach (var item2 in list2.Items)
                        {
                            if (item1 == item2 && cont != 1)
                                cont++;
                            else if(item1 == item2 && cont == 1)
                            {
                                recebido.Items.Remove(recebido.SelectedItem);
                                return;
                            }

                            if(list1 != list2 && item1 == item2)
                            { 
                                if (list1 == recebido)
                                {
                                    list2.Items.Remove(item1);
                                    return;
                                }
                                else
                                {
                                    list1.Items.Remove(item1);
                                    return;
                                }
                            }
                           

                        }
                    }

                }
            }
                               
        }

        private void listBox2_DragLeave(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;

            lb_item = lb.SelectedItem;
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (lb_item != null)
            {
                listBox2.Items.Add(lb_item);
                lb_item = null;
            }
            Console.WriteLine("DragEnter!");
            e.Effect = DragDropEffects.Copy;
        }


        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lb_item = null;

            if (listBox2.Items.Count == 0 || listBox2.SelectedIndex == -1)
            {
                return;
            }

            int index = listBox2.IndexFromPoint(e.X, e.Y);
            string s = listBox2.Items[index].ToString();
            DragDropEffects dde2 = DoDragDrop(s, DragDropEffects.All);
        }

        private void listBox3_DragLeave(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;

            lb_item = lb.SelectedItem;
        }

        private void listBox3_DragEnter(object sender, DragEventArgs e)
        {
            if (lb_item != null)
            {
                listBox3.Items.Add(lb_item);
                lb_item = null;
            }
            Console.WriteLine("DragEnter!");
            e.Effect = DragDropEffects.Copy;
        }


        private void listBox3_MouseDown(object sender, MouseEventArgs e)
        {
            lb_item = null;

            if (listBox3.Items.Count == 0 || listBox3.SelectedIndex == -1)
            {
                return;
            }

            int index = listBox3.IndexFromPoint(e.X, e.Y);
            string s = listBox3.Items[index].ToString();
            DragDropEffects dde3 = DoDragDrop(s, DragDropEffects.All);
        }

        private void button5_Click(object sender, MouseEventArgs e)
        {
            MouseEventArgs ladoBotao = (MouseEventArgs)e;            

            if (ladoBotao.Button == MouseButtons.Left)
            {
                if (!listBox1.Items.Contains(textBox1.Text) && textBox1.Text.Any())
                {
                    string text = "";
                    switch (contador)
                    {
                        case 0:
                            text = "★     " + textBox1.Text;
                            break;
                        case 1:
                            text = "★★  " + textBox1.Text;
                            break;
                        case 2:
                            text = "★★★" + textBox1.Text;
                            break;
                    }
                    listBox1.Items.Add(text);
                }
                    

                textBox1.Clear();
            }

            else if(ladoBotao.Button == MouseButtons.Right)
            {
                if (contador != 2)
                    contador++;
                else
                    contador = 0;
                button5.Text = prioridade[contador];
                
            }
        }

       
    }
}
