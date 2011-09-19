﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace RoseCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(cartasTab);
            tabControl1.TabPages.Remove(coordenadasTab);
            tabControl1.TabPages.Remove(declinacaoTab);
            tabControl1.TabPages.Remove(unidadesTab);
            tabControl1.TabPages.Remove(ventosTab);

            linkLabel1.Text = "http://code.google.com/p/rosecalc/";
            linkLabel1.Links.Add(0, 34, "http://code.google.com/p/rosecalc/");
            label23.Text = "Versão "+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            escRegDistMapaUnid.SelectedIndex = 1;
            escRegDistRealUnid.SelectedIndex = 2;
            escCurvDistUnit.SelectedIndex = 2;
            escCurvDistUnit.SelectedValueChanged += button2_Click;
            escPrecPrecUnit.SelectedIndex = 2;
            escPrecPrecUnit.SelectedValueChanged += button3_Click;
            escDistMapaUnit.SelectedIndex = 1;
            escDistRealUnit.SelectedIndex = 2;
            escDistRealUnit.SelectedValueChanged += button4_Click;
            decDistUnit.SelectedIndex = 2;
            decElevUnit.SelectedIndex = 2;
        }

        public decimal ConverteMetro(decimal a, string aTipo)
        {
            decimal c = 0;
            if (aTipo == "centimetros")
            {               
                c = a / 100;                
            }
            if (aTipo == "milimetros")
            {
                c = a / 1000;
            }
            if (aTipo == "metros")
            {
                c = a * 1;
            }
            if (aTipo == "kilometros")
            {
                c = a * 1000;
            }
            return c;                  
        }

        public decimal ConverteDeMetro(decimal a, string aTipo)
        {
            decimal c = 0;
            if (aTipo == "centimetros")
            {
                c = a * 100;
            }
            if (aTipo == "milimetros")
            {
                c = a * 1000;
            }
            if (aTipo == "metros")
            {
                c = a * 1;
            }
            if (aTipo == "kilometros")
            {
                c = a * 1/1000;
            }
            return c;
        }
             
        private void button1_Click(object sender, EventArgs e)
        {
            decimal d = ConverteMetro(escRegDistMapa.Value, escRegDistMapaUnid.SelectedItem.ToString());
            decimal D = ConverteMetro(escRegDistReal.Value, escRegDistRealUnid.SelectedItem.ToString());
            
            decimal escRegEscalaValor;
            escRegEscalaValor = D / d;            
            escRegEscala.Text = "1:"+Math.Round(escRegEscalaValor,2).ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal razao = (escCurvLeit.Value * escCurvEscMapa.Value) / (escCurvEscCurv.Value);
            decimal valor = ConverteDeMetro(razao,escCurvDistUnit.SelectedItem.ToString());   

            escCurvDist.Text = Math.Round(valor,2).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal razao = escPrecEsc.Value*2/10000;
            decimal valor = ConverteDeMetro(razao, escPrecPrecUnit.SelectedItem.ToString());
            
            escPrecPrec.Text = Math.Round(valor, 2).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decimal distMapa = ConverteMetro(escDistMapa.Value, escDistMapaUnit.SelectedItem.ToString());
            decimal esc = escEscMapa.Value;

            decimal distReal = ConverteDeMetro(distMapa * esc, escDistRealUnit.SelectedItem.ToString());
            escDistReal.Text = Math.Round(distReal, 2).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decimal dist = ConverteMetro(decDist.Value, decDistUnit.SelectedItem.ToString());
            decimal elev = ConverteMetro(decElev.Value, decElevUnit.SelectedItem.ToString());

            decimal d = elev / dist;

            decimal decper = d * 100;            
            decimal decgraus = Convert.ToDecimal(Math.Atan(Convert.ToDouble(d))*180/Math.PI);

            decGraus.Text = Math.Round(decgraus,2).ToString()+"°";
            decPer.Text = Math.Round(decper,2).ToString()+" %";
        }


        private void button6_Click(object sender, EventArgs e)
        {            
            listBox1.Items.Add(float.Parse(perfilDist.Value.ToString()));            
            listBox2.Items.Add(float.Parse(perfilElev.Value.ToString()));

            // Declaração dos dados e criação da lista de pares ordenados

            // Declaração dos arrays
            double[] dist = new double[listBox1.Items.Count];
            double[] elev = new double[listBox1.Items.Count];

            // Povoamento do array com os valores da listBox
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                dist[i] = Convert.ToDouble(listBox1.Items[i]);
                elev[i] = Convert.ToDouble(listBox2.Items[i]);
            }

            PointPairList list1 = new PointPairList();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                list1.Add(dist[i], elev[i]);
            }

            // Cria controle e referência ao gráfico
            ZedGraphControl zgc = zedGraphControl1;
            GraphPane myPane = zgc.GraphPane;        

            //Adiciona série
            zgc.GraphPane.CurveList.Clear(); //Apaga a série do gráfico
            LineItem myCurve = myPane.AddCurve("",list1, Color.Black, SymbolType.XCross);
            myCurve.Line.Fill = new Fill (Color.White, Color.Blue, 45F);
            myCurve.Line.Width = 3;
            zgc.AxisChange();
            zedGraphControl1.Refresh();
            
        }



        private void tabControl1_Enter(object sender, EventArgs e)
        {
            ZedGraphControl zgc = zedGraphControl1;
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.FontSpec.Family = "Verdana";
            myPane.Title.FontSpec.Size = 11;
            myPane.YAxis.Title.FontSpec.Family = "Verdana";
            myPane.YAxis.Title.FontSpec.Size = 9;
            myPane.XAxis.Title.FontSpec.Family = "Verdana";
            myPane.XAxis.Title.FontSpec.Size = 9;
            myPane.YAxis.Scale.FontSpec.Size = 9;
            myPane.XAxis.Scale.FontSpec.Size = 9;
            myPane.Title.Text = "Perfil de relevo";
            myPane.XAxis.Title.Text = "Distância";
            myPane.YAxis.Title.Text = "Elevação";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }











        

    }
}
