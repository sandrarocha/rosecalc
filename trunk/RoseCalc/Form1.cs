using System;
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

            // CONFIGURAÇÕES INICIAIS DAS ABAS

            //Elimina algumas tabs da compilação (que ainda não estão prontas)
            tabControl1.TabPages.Remove(cartasTab);
            //tabControl1.TabPages.Remove(coordenadasTab);
            tabControl1.TabPages.Remove(declinacaoTab);
            tabControl1.TabPages.Remove(unidadesTab);            
            tabControl1.TabPages.Remove(rumoTab);
            tabControl1.TabPages.Remove(transporteTab);
            tabControl1.TabPages.Remove(topografiaTab);

            //Aba 'Sobre'

            //Link para o projeto na aba 'Sobre'
            linkLabel1.Text = "http://code.google.com/p/rosecalc/";
            linkLabel1.Links.Add(0, 34, "http://code.google.com/p/rosecalc/");
            //label23.Text = "Versão "+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label23.Text = "Versão 1.0.0.6";

            //Aba 'Perfil de relevo'

            //Valores iniciais das combobox da aba 'Perfil de relevo'
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

            //Perfil de Relevo
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
            myPane.Chart.Fill = new Fill(Color.White, (perfilFundoCor.SelectedColor), 90F);
            zedGraphControl1.Refresh();

            //Aba gráfico dos ventos

            //Gráfico dos ventos
            ZedGraphControl zgc2 = zedGraphControl2;
            GraphPane myPane2 = zgc2.GraphPane;
            myPane2.Title.Text = "";
            myPane2.XAxis.Title.Text = "";
            myPane2.YAxis.Title.Text = "";
            myPane2.XAxis.Scale.FontSpec.Size = 10;
            myPane2.YAxis.Scale.FontSpec.Size = 10;
            myPane2.XAxis.MajorTic.IsAllTics = true;
            myPane2.XAxis.MinorTic.IsAllTics = true;
            myPane2.XAxis.Title.IsTitleAtCross = false;
            myPane2.XAxis.Cross = 0;
            myPane2.XAxis.Scale.IsSkipFirstLabel = true;
            myPane2.XAxis.Scale.IsSkipLastLabel = true;
            myPane2.XAxis.Scale.IsSkipCrossLabel = true;
            myPane2.YAxis.MajorTic.IsAllTics = true;
            myPane2.YAxis.MinorTic.IsAllTics = true;
            myPane2.YAxis.Title.IsTitleAtCross = false;
            myPane2.YAxis.Cross = 0;
            myPane2.YAxis.Scale.IsSkipFirstLabel = true;
            myPane2.YAxis.Scale.IsSkipLastLabel = true;
            myPane2.YAxis.Scale.IsSkipCrossLabel = true;
            myPane2.Title.Text = ventoTitulo.Text;
            myPane2.XAxis.Title.Text = "";
            myPane2.YAxis.Title.Text = "";
            myPane2.XAxis.Scale.FontSpec.Size = 10;
            myPane2.YAxis.Scale.FontSpec.Size = 10;
            myPane2.XAxis.Scale.Min = -1;
            myPane2.XAxis.Scale.Max = 1;
            myPane2.YAxis.Scale.Min = -1;
            myPane2.YAxis.Scale.Max = 1;
            TextObj noroeste = new TextObj("Noroeste", 0.0, 0.0);
            noroeste.Location.CoordinateFrame = CoordType.ChartFraction;
            noroeste.Location.AlignH = AlignH.Left;
            noroeste.Location.AlignV = AlignV.Bottom;
            noroeste.FontSpec.Border.IsVisible = false;
            noroeste.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(noroeste);
            TextObj sudeste = new TextObj("Sudeste", 1.0, 1.0);
            sudeste.Location.CoordinateFrame = CoordType.ChartFraction;
            sudeste.Location.AlignH = AlignH.Right;
            sudeste.Location.AlignV = AlignV.Top;
            sudeste.FontSpec.Border.IsVisible = false;
            sudeste.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(sudeste);
            TextObj sudoeste = new TextObj("Sudoeste", 0.0, 1.0);
            sudoeste.Location.CoordinateFrame = CoordType.ChartFraction;
            sudoeste.Location.AlignH = AlignH.Left;
            sudoeste.Location.AlignV = AlignV.Top;
            sudoeste.FontSpec.Border.IsVisible = false;
            sudoeste.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(sudoeste);
            TextObj nordeste = new TextObj("Nordeste", 1.0, 0);
            nordeste.Location.CoordinateFrame = CoordType.ChartFraction;
            nordeste.Location.AlignH = AlignH.Right;
            nordeste.Location.AlignV = AlignV.Bottom;
            nordeste.FontSpec.Border.IsVisible = false;
            nordeste.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(nordeste);
            TextObj norte = new TextObj("Norte", .5, 0);
            norte.Location.CoordinateFrame = CoordType.ChartFraction;
            norte.Location.AlignH = AlignH.Center;
            norte.Location.AlignV = AlignV.Bottom;
            norte.FontSpec.Border.IsVisible = false;
            norte.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(norte);
            TextObj oeste = new TextObj("Oeste", 0, .5);
            oeste.Location.CoordinateFrame = CoordType.ChartFraction;
            oeste.Location.AlignH = AlignH.Left;
            oeste.Location.AlignV = AlignV.Bottom;
            oeste.FontSpec.Border.IsVisible = false;
            oeste.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(oeste);
            TextObj leste = new TextObj("Leste", 1, .5);
            leste.Location.CoordinateFrame = CoordType.ChartFraction;
            leste.Location.AlignH = AlignH.Right;
            leste.Location.AlignV = AlignV.Bottom;
            leste.FontSpec.Border.IsVisible = false;
            leste.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(leste);
            TextObj sul = new TextObj("Sul", .5, 1);
            sul.Location.CoordinateFrame = CoordType.ChartFraction;
            sul.Location.AlignH = AlignH.Center;
            sul.Location.AlignV = AlignV.Top;
            sul.FontSpec.Border.IsVisible = false;
            sul.FontSpec.Fill.IsVisible = false;
            zgc2.MasterPane[0].GraphObjList.Add(sul);
            zedGraphControl2.Refresh();

            //Aba Transformação de coordenadas

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 1;
  
            

        }


        //Função: Converte de qualquer unidade para metro
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


        //Função: Converte de metro para qualquer unidade
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
        
        //Aba 'Escalas'
     
        //Função: Determina a escala
        private void button1_Click(object sender, EventArgs e)
        {
            decimal d = ConverteMetro(escRegDistMapa.Value, escRegDistMapaUnid.SelectedItem.ToString());
            decimal D = ConverteMetro(escRegDistReal.Value, escRegDistRealUnid.SelectedItem.ToString());
            
            decimal escRegEscalaValor;
            escRegEscalaValor = D / d;            
            escRegEscala.Text = "1:"+Math.Round(escRegEscalaValor,2).ToString();
            
        }


        //Botão: Calcula distância real com medida a partir de curvímetro ou escalímetro
        private void button2_Click(object sender, EventArgs e)
        {
            decimal razao = (escCurvLeit.Value * escCurvEscMapa.Value) / (escCurvEscCurv.Value);
            decimal valor = ConverteDeMetro(razao,escCurvDistUnit.SelectedItem.ToString());   

            escCurvDist.Text = Math.Round(valor,2).ToString();
        }


        //Botão: Calcula precisão gráfica
        private void button3_Click(object sender, EventArgs e)
        {
            decimal razao = escPrecEsc.Value*2/10000;
            decimal valor = ConverteDeMetro(razao, escPrecPrecUnit.SelectedItem.ToString());
            
            escPrecPrec.Text = Math.Round(valor, 2).ToString();
        }


        //Botão: Calcula distância real com medida a partir da régua
        private void button4_Click(object sender, EventArgs e)
        {
            decimal distMapa = ConverteMetro(escDistMapa.Value, escDistMapaUnit.SelectedItem.ToString());
            decimal esc = escEscMapa.Value;

            decimal distReal = ConverteDeMetro(distMapa * esc, escDistRealUnit.SelectedItem.ToString());
            escDistReal.Text = Math.Round(distReal, 2).ToString();
        }


        //Aba 'Declividade'

        //Botão:  Calcula declividade
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

        //Aba 'Perfil de relevo'

        //Função: Gráfico do perfil de relevo
        private void graficoPerfil()
        {
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
            LineItem myCurve = myPane.AddCurve("", list1, perfilLinhaCor.SelectedColor, SymbolType.XCross);            
            myCurve.Line.Fill = new Fill(Color.White, perfilGraficoCor.SelectedColor, 45F);            
            myCurve.Line.Width = 3;
            zgc.AxisChange();            

            //Atualiza títulos
            myPane.Title.Text = perfilTitulo.Text;
            myPane.XAxis.Title.Text = perfilEixoX.Text;
            myPane.YAxis.Title.Text = perfilEixoY.Text;

            //Cores do fundo do gráfico
            myPane.Chart.Fill = new Fill(Color.White, (perfilFundoCor.SelectedColor), 90F);

            //Atualiza o gráfico
            zedGraphControl1.Refresh();
        }


        //Botão: Adiciona valores nas listbox da aba 'Perfil'
        private void button6_Click(object sender, EventArgs e)
        {            
            listBox1.Items.Add(float.Parse(perfilDist.Value.ToString()));            
            listBox2.Items.Add(float.Parse(perfilElev.Value.ToString()));
            graficoPerfil();
            
        }


        //Botão: Limpar as listbox da aba 'Perfil'
        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
        }


        //Aba 'Sobre'

        //Link para o projeto no code.google, na aba 'Sobre'
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        //Aba 'Gráfico dos ventos'

        public decimal graficoVentoMax(decimal N, decimal NE, decimal E, decimal SE, decimal S, decimal SO, decimal O, decimal NO)
        {
            decimal ventoMax;
            decimal[] ventos = new decimal[8] { N, NE, E, SE, S, SO, O, NO };
            return ventoMax = ventos.Max();
        }

        private void graficoVento()
        {
            ZedGraphControl zgc2 = zedGraphControl2;
            GraphPane myPane2 = zgc2.GraphPane;

            //Adiciona série 
            zgc2.GraphPane.CurveList.Clear(); //Apaga a série do gráfico


            RadarPointList list1 = new RadarPointList();
            list1.Add(Convert.ToDouble(ventoN.Value), 1);
            list1.Add(Convert.ToDouble(ventoNE.Value), 2);
            list1.Add(Convert.ToDouble(ventoE.Value), 3);
            list1.Add(Convert.ToDouble(ventoSE.Value), 4);
            list1.Add(Convert.ToDouble(ventoS.Value), 5);
            list1.Add(Convert.ToDouble(ventoSO.Value), 6);
            list1.Add(Convert.ToDouble(ventoO.Value), 7);
            list1.Add(Convert.ToDouble(ventoNO.Value), 8);
            
            LineItem myCurve = myPane2.AddCurve("", list1, ventoCorLinha.SelectedColor, SymbolType.None);
            myCurve.Line.Fill = new Fill(Color.White, ventoCorGraf.SelectedColor, 45F);            
            myCurve.Line.Width = (float)ventoExpLinha.Value;

            //Criar LineItem para simular os outros eixos??            

            PointPairList list2 = new PointPairList();
            list2.Add(-1000, 1000);
            list2.Add(1000, -1000);
            
            LineItem myAxis1 = myPane2.AddCurve("", list2, Color.Black, SymbolType.Circle);
            zedGraphControl2.Refresh();

            PointPairList list3 = new PointPairList();
            list3.Add(1000, 1000);
            list3.Add(-1000, -1000);

            LineItem myAxis2 = myPane2.AddCurve("", list3, Color.Black, SymbolType.Circle);
            zedGraphControl2.Refresh();

            zgc2.GraphPane.CurveList[2] = myCurve;
            zgc2.GraphPane.CurveList[1] = myAxis2;
            zgc2.GraphPane.CurveList[0] = myAxis1;

            //Atualiza títulos
            myPane2.Title.Text = ventoTitulo.Text;
            myPane2.XAxis.Title.Text = "";
            myPane2.YAxis.Title.Text = "";

            myPane2.XAxis.Scale.FontSpec.Size = 10;
            myPane2.YAxis.Scale.FontSpec.Size = 10;

            //Setting X axis Minimum and Maximum axis and the steps

            double valorMax = Convert.ToDouble(graficoVentoMax(ventoN.Value, ventoNE.Value, ventoE.Value, ventoSE.Value, ventoS.Value, ventoSO.Value, ventoO.Value, ventoNO.Value));

            myPane2.XAxis.Scale.Min = -valorMax - .2 * valorMax;
            myPane2.XAxis.Scale.Max = valorMax + .2 * valorMax;

            myPane2.YAxis.Scale.Min = -valorMax - .2 * valorMax;
            myPane2.YAxis.Scale.Max = valorMax + .2 * valorMax;


            myPane2.XAxis.MajorTic.IsAllTics = true;
            myPane2.XAxis.MinorTic.IsAllTics = true;
            myPane2.XAxis.Title.IsTitleAtCross = false;
            myPane2.XAxis.Cross = 0;
            myPane2.XAxis.Scale.IsSkipFirstLabel = true;
            myPane2.XAxis.Scale.IsSkipLastLabel = true;
            myPane2.XAxis.Scale.IsSkipCrossLabel = true;

            myPane2.YAxis.MajorTic.IsAllTics = true;
            myPane2.YAxis.MinorTic.IsAllTics = true;
            myPane2.YAxis.Title.IsTitleAtCross = false;
            myPane2.YAxis.Cross = 0;
            myPane2.YAxis.Scale.IsSkipFirstLabel = true;
            myPane2.YAxis.Scale.IsSkipLastLabel = true;
            myPane2.YAxis.Scale.IsSkipCrossLabel = true;

            TextObj noroeste = new TextObj("Noroeste", 0.0, 0.0); 
            noroeste.Location.CoordinateFrame = CoordType.ChartFraction;
            noroeste.Location.AlignH = AlignH.Left;     
            noroeste.Location.AlignV = AlignV.Bottom;   
            noroeste.FontSpec.Border.IsVisible = false; 
            noroeste.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(noroeste);

            TextObj sudeste = new TextObj("Sudeste", 1.0, 1.0); 
            sudeste.Location.CoordinateFrame = CoordType.ChartFraction;
            sudeste.Location.AlignH = AlignH.Right;     
            sudeste.Location.AlignV = AlignV.Top;   
            sudeste.FontSpec.Border.IsVisible = false; 
            sudeste.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(sudeste);

            TextObj sudoeste = new TextObj("Sudoeste", 0.0, 1.0); 
            sudoeste.Location.CoordinateFrame = CoordType.ChartFraction;
            sudoeste.Location.AlignH = AlignH.Left;     
            sudoeste.Location.AlignV = AlignV.Top;   
            sudoeste.FontSpec.Border.IsVisible = false; 
            sudoeste.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(sudoeste);

            TextObj nordeste = new TextObj("Nordeste", 1.0, 0); 
            nordeste.Location.CoordinateFrame = CoordType.ChartFraction;
            nordeste.Location.AlignH = AlignH.Right;     
            nordeste.Location.AlignV = AlignV.Bottom;   
            nordeste.FontSpec.Border.IsVisible = false; 
            nordeste.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(nordeste);

            TextObj norte = new TextObj("Norte", .5,0); 
            norte.Location.CoordinateFrame = CoordType.ChartFraction;
            norte.Location.AlignH = AlignH.Center;     
            norte.Location.AlignV = AlignV.Bottom;   
            norte.FontSpec.Border.IsVisible = false; 
            norte.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(norte);

            TextObj oeste = new TextObj("Oeste", 0, .5); 
            oeste.Location.CoordinateFrame = CoordType.ChartFraction;
            oeste.Location.AlignH = AlignH.Left;     
            oeste.Location.AlignV = AlignV.Bottom;   
            oeste.FontSpec.Border.IsVisible = false; 
            oeste.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(oeste);

            TextObj leste = new TextObj("Leste", 1, .5); 
            leste.Location.CoordinateFrame = CoordType.ChartFraction;
            leste.Location.AlignH = AlignH.Right;     
            leste.Location.AlignV = AlignV.Bottom;   
            leste.FontSpec.Border.IsVisible = false; 
            leste.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(leste);

            TextObj sul = new TextObj("Sul", .5, 1); 
            sul.Location.CoordinateFrame = CoordType.ChartFraction;
            sul.Location.AlignH = AlignH.Center;     
            sul.Location.AlignV = AlignV.Top;   
            sul.FontSpec.Border.IsVisible = false; 
            sul.FontSpec.Fill.IsVisible = false;   
            zgc2.MasterPane[0].GraphObjList.Add(sul);

            //Atualiza o gráfico            
            zgc2.AxisChange();
            zgc2.Refresh();
        }

        //Gráfico dos ventos
        private void button8_Click(object sender, EventArgs e)
        {
            graficoVento();
            
        }


        //Atualiza gráfico do perfil
        private void perfilGraficoCor_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            graficoPerfil();
        }

        private void perfilLinhaCor_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            graficoPerfil();
        }

        private void perfilTitulo_TextChanged(object sender, EventArgs e)
        {
            graficoPerfil();
        }

        private void perfilEixoX_TextChanged(object sender, EventArgs e)
        {
            graficoPerfil();
        }

        private void perfilEixoY_TextChanged(object sender, EventArgs e)
        {
            graficoPerfil();
        }

        private void perfilFundoCor_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            graficoPerfil();
        }


        //Limpar valores da aba 'Perfil'
        private void button9_Click(object sender, EventArgs e)
        {
            escRegDistMapa.Value = 0;
            escRegDistReal.Value = 0;
            escRegEscala.Text = "";
            escDistMapa.Value = 0;
            escEscMapa.Value = 0;
            escDistReal.Text = "";
            escCurvLeit.Value = 0;
            escCurvEscCurv.Value = 0;
            escCurvEscMapa.Value = 0;
            escCurvDist.Text = "";
            escPrecEsc.Value = 0;
            escPrecPrec.Text = "";

        }

        //Limpar valores da aba "Declividade"
        private void button10_Click(object sender, EventArgs e)
        {
            decElev.Value = 0;
            decDist.Value = 0;
            decGraus.Text = "";
            decPer.Text = "";
        }

        private void ventoTitulo_TextChanged(object sender, EventArgs e)
        {
            graficoVento();
        }

        private void ventoCorLinha_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            graficoVento();
        }

        private void ventoExpLinha_ValueChanged(object sender, EventArgs e)
        {
            graficoVento();
        }

        private void ventoCorGraf_ColorChanged(object sender, ColorComboTestApp.ColorChangeArgs e)
        {
            graficoVento();
        }        

        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                decimal vdecimal = numericUpDown1.Value + (numericUpDown2.Value * 1 / 60) + (numericUpDown3.Value * 1 / 3600);
                numericUpDown4.Value = vdecimal;
            }
            if (radioButton2.Checked == true)
            {
                decimal vgraus = Math.Truncate(numericUpDown4.Value);
                numericUpDown1.Value = vgraus;

                decimal vresto = numericUpDown4.Value - vgraus;

                decimal vminutos = Math.Truncate(vresto * 60);
                numericUpDown2.Value = vminutos;

                decimal vsegundos = ((vresto*60)-vminutos)*60;
                numericUpDown3.Value = vsegundos;                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.ReadOnly = true;
            numericUpDown1.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown1.Increment = 0;
            numericUpDown2.ReadOnly = true;
            numericUpDown2.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown2.Increment = 0;
            numericUpDown3.ReadOnly = true;
            numericUpDown3.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown3.Increment = 0;            
            numericUpDown4.ReadOnly = false;
            numericUpDown4.Increment = 1;
            numericUpDown4.BackColor = Color.FromArgb(255,255,255);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.ReadOnly = false;
            numericUpDown1.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown1.Increment = 1;
            numericUpDown2.ReadOnly = false;
            numericUpDown2.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown2.Increment = 1;
            numericUpDown3.ReadOnly = false;
            numericUpDown3.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown3.Increment = 1;
            numericUpDown4.ReadOnly = true;
            numericUpDown4.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown4.Increment = 0;
            
            
        }

        // Conversão de coordenadas geodésicas para UTM. Duas funções foram usadas, iguais no conteúdo, mudando
        // apenas o final, uma retornando N e outra E

        public double GeogParaUTMNorte(double dtheta, double dgama)
        {
            //Conversão das coordenadas de graus decimais para radianos e tratamento Sul/Norte, Leste/Oeste
                        
            //Latitude
            double theta = 0;
            if (comboBox2.Text == "Norte")
            {
                theta = Math.PI / 180 * dtheta; //Coordenada positiva
            }
            if (comboBox2.Text == "Sul")
            {
                theta = -1 * (Math.PI / 180 * dtheta); //Coordenada negativa             
            }
            
            //Longitude    
            double gama = 0;
            if (comboBox3.Text == "Leste")
            {
                gama = Math.PI / 180 * dgama; //Coordenada positiva
            }
            if (comboBox3.Text == "Oeste")
            {
                gama = -1 * Math.PI / 180 * -dgama; //Coordenada negativa             
            }           
            
            
            //Fator de escala da projeção (UTM)
            double k0 = 0.9996;

            //Variáveis do datum
            double a = 0; //Raio equatorial
            double b = 0; //Raio polar            

            if (comboBox1.Text == "WGS-1984")
            {
                a = 6378137;
                b = 6356752.314245179300000000;
            }
            if (comboBox1.Text == "SIRGAS-2000")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }
            if (comboBox1.Text == "SAD-1969")
            {
                a = 6378160;
                b = 6356774.719195305400000000;
            }
            if (comboBox1.Text == "Córrego Alegre")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Hayford)")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Bessel)")
            {
                a = 6377397.155000000300000000;
                b = 6356078.962818188600000000;
            }
            if (comboBox1.Text == "Datum 1973")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "ED-1950")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "WGS-1972")
            {
                a = 6378135;
                b = 6356750.520016093700000000;
            }
            if (comboBox1.Text == "NAD-1983")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }

            double f = (a - b) / a; //Achatamento
            double invf = 1 / f;    //Achatamento inverso
            double rm = Math.Pow(a * b, 0.5);  //Raio médio            
            double e = Math.Sqrt(1 - Math.Pow(b / a, 2));  //Excentricidade
            double e2 = e * e / (1 - e * e);  //
            double n = (a - b) / (a + b);
            double rho = a * (1 - e * e) / (Math.Pow(1 - (e * Math.Pow(Math.Sin(theta), 2)), 1.5)); //Raio de curvatura 1
            double nu = a / (Math.Pow(1 - Math.Pow(e * Math.Sin(theta), 2), 0.5));  //Raio de curvatura 2

            //Cálculo do arco meridional
            double A0 = a * (1 - n + (5 * n * n / 4) * (1 - n) + (81 * Math.Pow(n, 4) / 64) * (1 - n));  
            double B0 = (3 * a * n / 2) * (1 - n - (7 * n * n / 8) * (1 - n) + 55 * Math.Pow(n, 4) / 64);
            double C0 = (15 * a * n * n / 16) * (1 - n + (3 * n * n / 4) * (1 - n));
            double D0 = (35 * a * Math.Pow(n, 3) / 48) * (1 - n + 11 * n * n / 16);
            double E0 = (315 * a * Math.Pow(n, 4) / 51) * (1 - n);
            double S = A0 * theta - B0 * Math.Sin(2 * theta) + C0 * Math.Sin(4 * theta) - D0 * Math.Sin(6 * theta) + E0 * Math.Sin(8 * theta);  //Arco meridional

            //Constante de cálculo (em radianos)
            double prad = 0;
            if (comboBox3.Text == "Oeste")            
            {
                prad = (-dgama - (6 * (Math.Floor((180 - dgama) / 6) + 1) - 183)) * (Math.PI / 180); //Oeste
            }
            if (comboBox3.Text == "Leste")  
            {
                prad = (dgama - (6 * (Math.Floor((dgama) / 6) + 31) - 183)) * (Math.PI / 180); //Leste
            }            
            
            //Coeficientes para as coordenadas UTM
            double Ki = S * k0;
            double Kii = nu * Math.Sin(theta) * Math.Cos(theta) * k0 / 2;
            double Kiii = ((nu * Math.Sin(theta) * Math.Pow(Math.Cos(theta), 3)) / 24) * (5 - Math.Pow(Math.Tan(theta), 2) + 9 * e2 * Math.Pow(Math.Cos(theta), 2) + 4 * Math.Pow(e2, 2) * Math.Pow(Math.Cos(theta), 4)) * k0;
            double Kiv = nu * Math.Cos(theta) * k0;
            double Kv = Math.Pow(Math.Cos(theta), 3) * (nu / 6) * (1 - Math.Pow(Math.Tan(theta), 2) + e2 * Math.Pow(Math.Cos(theta), 2)) * k0;
            //double A6 = (Math.Pow(prad * 0, 2) * nu * Math.Sin(theta) * Math.Pow(Math.Cos(theta), 5) / 720) * (61 - 58 * Math.Pow(Math.Tan(theta), 2) + Math.Pow(Math.Tan(theta), 4) + 270 * e2 * Math.Pow(Math.Sin(theta), 2)) * k0;
            //double A6 = 0;


            //Cálculo de N
            double N = 0;
            if (comboBox2.Text == "Norte")
            {
                N = (Ki + Kii * prad * prad + Kiii * Math.Pow(prad, 4));                
            }
            if (comboBox2.Text == "Sul")
            {
                N = 10000000 + (Ki + Kii * prad * prad + Kiii * Math.Pow(prad, 4));               
            }
            
            //Cálculo de E
            ////double E = 500000 + (Kiv * prad + Kv * Math.Pow(prad, 3));
            
            return N; //Função retorna N

            //Fonte dos cálculos: http://www.uwgb.edu/dutchs/UsefulData/UTMFormulas.HTM e http://www.uwgb.edu/dutchs/UsefulData/UTMConversions1.xls
            //Fonte das constantes dos data: ESRI. Documentação do ArcGIS 10.
            
        }    

        public double GeogParaUTMEste(double dtheta, double dgama)
        {
            //Latitude
            double theta = 0;
            if (comboBox2.Text == "Norte")
            {
                theta = Math.PI / 180 * dtheta; //Coordenada positiva
            }
            if (comboBox2.Text == "Sul")
            {
                theta = -1 * (Math.PI / 180 * dtheta); //Coordenada negativa             
            }
            //Longitude    
            double gama = 0;
            if (comboBox3.Text == "Leste")
            {                
                gama = Math.PI / 180 * dgama; //Coordenada positiva
            }
            if (comboBox3.Text == "Oeste")
            {
                gama = -1 * Math.PI / 180 * dgama; //Coordenada negativa             
            }

            double a = 0;
            double b = 0;
            double k0 = 0.9996;

            if (comboBox1.Text == "WGS-1984")
            {
                a = 6378137;
                b = 6356752.314245179300000000;
            }
            if (comboBox1.Text == "SIRGAS-2000")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }
            if (comboBox1.Text == "SAD-1969")
            {
                a = 6378160;
                b = 6356774.719195305400000000;
            }
            if (comboBox1.Text == "Córrego Alegre")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }            
            if (comboBox1.Text == "Lisboa (Hayford)")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Bessel)")
            {
                a = 6377397.155000000300000000;
                b = 6356078.962818188600000000;
            }
            if (comboBox1.Text == "Datum 1973")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "ED-1950")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "WGS-1972")
            {
                a = 6378135;
                b = 6356750.520016093700000000;
            }
            if (comboBox1.Text == "NAD-1983")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }
          
            double f = (a - b) / a;
            double invf = 1 / f;
            double rm = Math.Pow(a * b, 0.5);
            double e = Math.Sqrt(1 - Math.Pow(b / a, 2));
            double e2 = e * e / (1 - e * e);
            double n = (a - b) / (a + b);
            double rho = a * (1 - e * e) / (Math.Pow(1 - (e * Math.Pow(Math.Sin(theta), 2)), 1.5));
            double nu = a / (Math.Pow(1 - Math.Pow(e * Math.Sin(theta), 2), 0.5));

            double A0 = a * (1 - n + (5 * n * n / 4) * (1 - n) + (81 * Math.Pow(n, 4) / 64) * (1 - n));
            double B0 = (3 * a * n / 2) * (1 - n - (7 * n * n / 8) * (1 - n) + 55 * Math.Pow(n, 4) / 64);
            double C0 = (15 * a * n * n / 16) * (1 - n + (3 * n * n / 4) * (1 - n));
            double D0 = (35 * a * Math.Pow(n, 3) / 48) * (1 - n + 11 * n * n / 16);
            double E0 = (315 * a * Math.Pow(n, 4) / 51) * (1 - n);
            double S = A0 * theta - B0 * Math.Sin(2 * theta) + C0 * Math.Sin(4 * theta) - D0 * Math.Sin(6 * theta) + E0 * Math.Sin(8 * theta);


            double prad = 0;
            if (comboBox3.Text == "Oeste")
            {
                prad = (-dgama - (6 * (Math.Floor((180 - dgama) / 6) + 1) - 183)) * (Math.PI / 180); //Oeste
            }
            if (comboBox3.Text == "Leste")
            {
                prad = (dgama - (6 * (Math.Floor((dgama) / 6) + 31) - 183)) * (Math.PI / 180); //Leste
            }
                        
            double Ki = S * k0;
            double Kii = nu * Math.Sin(theta) * Math.Cos(theta) * k0 / 2;
            double Kiii = ((nu * Math.Sin(theta) * Math.Pow(Math.Cos(theta), 3)) / 24) * (5 - Math.Pow(Math.Tan(theta), 2) + 9 * e2 * Math.Pow(Math.Cos(theta), 2) + 4 * Math.Pow(e2, 2) * Math.Pow(Math.Cos(theta), 4)) * k0;
            double Kiv = nu * Math.Cos(theta) * k0;
            double Kv = Math.Pow(Math.Cos(theta), 3) * (nu / 6) * (1 - Math.Pow(Math.Tan(theta), 2) + e2 * Math.Pow(Math.Cos(theta), 2)) * k0;

            //Calcula N
            ////double N = 0;
            ////if (comboBox2.Text == "Norte")
            ////{
            ////    N = (Ki + Kii * prad * prad + Kiii * Math.Pow(prad, 4));
            ////}
            ////if (comboBox2.Text == "Sul")
            ////{
            ////    N = 10000000 + (Ki + Kii * prad * prad + Kiii * Math.Pow(prad, 4));
            ////}

            //Calcula E
            double E = 500000 + (Kiv * prad + Kv * Math.Pow(prad, 3));
            
            return E; //Função retorna E
        }

        public double UTMZona(string leste, double longi)
        {            
            double zona;
            if (leste == "Oeste")
            {
                zona = Math.Floor((180 + -longi)/6)+1;
            }
            else
            {
                zona = Math.Floor(longi / 6) + 31;
            }

            return zona;
                
        }


        public double UTMParaGeogNorte(double x, double y)
        {
            //Fator de escala da projeção (UTM)
            double k0 = 0.9996;

            //Variáveis do datum
            double a = 0; //Raio equatorial
            double b = 0; //Raio polar            

            if (comboBox1.Text == "WGS-1984")
            {
                a = 6378137;
                b = 6356752.314245179300000000;
            }
            if (comboBox1.Text == "SIRGAS-2000")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }
            if (comboBox1.Text == "SAD-1969")
            {
                a = 6378160;
                b = 6356774.719195305400000000;
            }
            if (comboBox1.Text == "Córrego Alegre")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Hayford)")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Bessel)")
            {
                a = 6377397.155000000300000000;
                b = 6356078.962818188600000000;
            }
            if (comboBox1.Text == "Datum 1973")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "ED-1950")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "WGS-1972")
            {
                a = 6378135;
                b = 6356750.520016093700000000;
            }
            if (comboBox1.Text == "NAD-1983")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }

            //double f = (a - b) / a; //Achatamento
            //double invf = 1 / f;    //Achatamento inverso
            double rm = Math.Pow(a * b, 0.5);  //Raio médio            
            double ec = Math.Sqrt(1 - Math.Pow(b / a, 2));  //Excentricidade
            double  eisq = ec * ec / (1 - ec * ec);  //
            //double n = (a - b) / (a + b);
            //double rho = a * (1 - e * e) / (Math.Pow(1 - (e * Math.Pow(Math.Sin(theta), 2)), 1.5)); //Raio de curvatura 1
            //double nu = a / (Math.Pow(1 - Math.Pow(e * Math.Sin(theta), 2), 0.5));  //Raio de curvatura 2

            double arc = 0;
            if (comboBox4.Text == "Norte")
            {
                arc = y / k0;
            }
            if (comboBox4.Text == "Sul")
            {
                arc = (10000000-y) / k0;
            }

            double mu = arc / (a * (1 - Math.Pow(ec, 2) / 4 - 3 * Math.Pow(ec, 4) / 64 - 5 * Math.Pow(ec, 6) / 256));
            double ei = (1 - Math.Pow(1 - ec * ec, 0.5)) / (1 + Math.Pow(1 - ec * ec, 0.5));
            double ca = 3 * ei / 2 - 27 * Math.Pow(ei, 3) / 32;
            double cb = 21 * Math.Pow(ei, 2) / 16 - 55 * Math.Pow(ei, 4) / 32;
            double ccc = 151 * Math.Pow(ei, 3) / 96;
            double cd = 1097 * Math.Pow(ei, 4) / 512;
            double phi1 = mu + ca * Math.Sin(2 * mu) + cb * Math.Sin(4 * mu) + ccc * Math.Sin(6 * mu) + cd * Math.Sin(8 * mu);
            //double Sin1 = 0;
            double Q0 = eisq * Math.Pow(Math.Cos(phi1), 2);
            double t0 = Math.Pow(Math.Tan(phi1), 2);
            double n0 = a / Math.Pow(1 - (Math.Pow(ec * Math.Sin(phi1), 2)), 0.5);
            double r0 = a * (1 - ec * ec) / Math.Pow(1 - (Math.Pow(ec * Math.Sin(phi1), 2)), 1.5);
            double elinha = 500000 - x;
            double dd0 = elinha / (n0 * k0);

            double fact1 = n0 * Math.Tan(phi1) / r0;
            double fact2 = dd0 * dd0 / 2;
            double fact3 = (5 + 3 * t0 + 10 * Q0 - 4 * Q0 * Q0 - 9 * eisq) * Math.Pow(dd0, 4) / 24;
            double fact4 = (61 + 90 * t0 + 298 * Q0 + 45 * t0 * t0 - 252 * eisq - 3 * Q0 * Q0) * Math.Pow(dd0, 6) / 720;

            double lof1 = dd0;
            double lof2 = (1 + 2 * t0 + Q0) * Math.Pow(dd0, 3) / 6;
            double lof3 = (5 - 2 * Q0 + 28 * t0 - 3 * Math.Pow(Q0, 2) + 8 * eisq + 24 * Math.Pow(t0, 2)) * Math.Pow(dd0, 5) / 120;

            
            
            //double h20 = (lof1-lof2+lof3)/Math.Cos(phi1);
            //double longi = h20 * 180 / Math.PI;

            double lat = 180 * (phi1 - fact1 * (fact2 + fact3 + fact4)) / Math.PI;            
            return lat;


            //Fonte dos cálculos: http://www.uwgb.edu/dutchs/UsefulData/UTMFormulas.HTM e http://www.uwgb.edu/dutchs/UsefulData/UTMConversions1.xls
            //Fonte das constantes dos data: ESRI. Documentação do ArcGIS 10.

        }

        public double UTMParaGeogEste(double x, double y)
        {
            //Fator de escala da projeção (UTM)
            double k0 = 0.9996;

            //Variáveis do datum
            double a = 0; //Raio equatorial
            double b = 0; //Raio polar            

            if (comboBox1.Text == "WGS-1984")
            {
                a = 6378137;
                b = 6356752.314245179300000000;
            }
            if (comboBox1.Text == "SIRGAS-2000")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }
            if (comboBox1.Text == "SAD-1969")
            {
                a = 6378160;
                b = 6356774.719195305400000000;
            }
            if (comboBox1.Text == "Córrego Alegre")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Hayford)")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "Lisboa (Bessel)")
            {
                a = 6377397.155000000300000000;
                b = 6356078.962818188600000000;
            }
            if (comboBox1.Text == "Datum 1973")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "ED-1950")
            {
                a = 6378388;
                b = 6356911.946127946500000000;
            }
            if (comboBox1.Text == "WGS-1972")
            {
                a = 6378135;
                b = 6356750.520016093700000000;
            }
            if (comboBox1.Text == "NAD-1983")
            {
                a = 6378137;
                b = 6356752.314140356100000000;
            }

            //double f = (a - b) / a; //Achatamento
            //double invf = 1 / f;    //Achatamento inverso
            double rm = Math.Pow(a * b, 0.5);  //Raio médio            
            double ec = Math.Sqrt(1 - Math.Pow(b / a, 2));  //Excentricidade
            double eisq = ec * ec / (1 - ec * ec);
            //double n = (a - b) / (a + b);
            //double rho = a * (1 - e * e) / (Math.Pow(1 - (e * Math.Pow(Math.Sin(theta), 2)), 1.5)); //Raio de curvatura 1
            //double nu = a / (Math.Pow(1 - Math.Pow(e * Math.Sin(theta), 2), 0.5));  //Raio de curvatura 2

            double arc = 0;
            if (comboBox4.Text == "Norte")
            {
                arc = y / k0;
            }
            if (comboBox4.Text == "Sul")
            {
                arc = (10000000 - y) / k0;
            }

            double mu = arc / (a * (1 - Math.Pow(ec, 2) / 4 - 3 * Math.Pow(ec, 4) / 64 - 5 * Math.Pow(ec, 6) / 256));
            double ei = (1 - Math.Pow(1 - ec * ec, 0.5)) / (1 + Math.Pow(1 - ec * ec, 0.5));
            double ca = 3 * ei / 2 - 27 * Math.Pow(ei, 3) / 32;
            double cb = 21 * Math.Pow(ei, 2) / 16 - 55 * Math.Pow(ei, 4) / 32;
            double ccc = 151 * Math.Pow(ei, 3) / 96;
            double cd = 1097 * Math.Pow(ei, 4) / 512;
            double phi1 = mu + ca * Math.Sin(2 * mu) + cb * Math.Sin(4 * mu) + ccc * Math.Sin(6 * mu) + cd * Math.Sin(8 * mu);
            //double Sin1 = 0;
            double Q0 = eisq * Math.Pow(Math.Cos(phi1), 2);
            double t0 = Math.Pow(Math.Tan(phi1), 2);
            double n0 = a / Math.Pow(1 - (Math.Pow(ec * Math.Sin(phi1), 2)), 0.5);
            double r0 = a * (1 - ec * ec) / Math.Pow(1 - (Math.Pow(ec * Math.Sin(phi1), 2)), 1.5);
            double elinha = 500000 - x;
            double dd0 = elinha / (n0 * k0);

            double fact1 = n0 * Math.Tan(phi1) / r0;
            double fact2 = dd0 * dd0 / 2;
            double fact3 = (5 + 3 * t0 + 10 * Q0 - 4 * Q0 * Q0 - 9 * eisq) * Math.Pow(dd0, 4) / 24;                           
            double fact4 = (61 + 90 * t0 + 298 * Q0 + 45 * t0 * t0 - 252 * eisq - 3 * Q0 * Q0) * Math.Pow(dd0, 6) / 720;

            double lof1 = dd0;
            double lof2 = (1 + 2 * t0 + Q0) * Math.Pow(dd0, 3) / 6;
            double lof3 = (5 - 2 * Q0 + 28 * t0 - 3 * Math.Pow(Q0, 2) + 8 * eisq + 24 * Math.Pow(t0, 2)) * Math.Pow(dd0, 5) / 120;

            //double lat = phi1 * 180 / Math.PI;

            double h20 = (lof1 - lof2 + lof3) / Math.Cos(phi1);
                        
            double e19 = Convert.ToDouble(numericUpDown9.Value);
            double h19 = 0;
            if (e19 > 0)
            {
                h19 = 6*e19-183;
            }
            if (e19 <= 0)
            {
                h19 = 3;
            }            

            double longi = h19 - (h20 * 180 / Math.PI);

            //double longi2=0;
            //if (longi < 0)
            //{
            //    longi2 =  longi * -1;
            //}
            //if (longi >= 0)
            //{
            //    longi2 = longi;
            //}

            return longi;


            //Fonte dos cálculos: http://www.uwgb.edu/dutchs/UsefulData/UTMFormulas.HTM e http://www.uwgb.edu/dutchs/UsefulData/UTMConversions1.xls
            //Fonte das constantes dos data: ESRI. Documentação do ArcGIS 10.

        }




        private void button12_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                numericUpDown8.Value = Convert.ToDecimal(GeogParaUTMNorte(Convert.ToDouble(numericUpDown5.Value), Convert.ToDouble(numericUpDown6.Value)));
                numericUpDown7.Value = Convert.ToDecimal(GeogParaUTMEste(Convert.ToDouble(numericUpDown5.Value), Convert.ToDouble(numericUpDown6.Value)));
                numericUpDown9.Value = Convert.ToDecimal(UTMZona(comboBox3.Text,Convert.ToDouble(numericUpDown6.Value)));
                comboBox4.Text = comboBox2.Text;
            }
            if (radioButton3.Checked == true)
            {               
                numericUpDown5.Value = Convert.ToDecimal(UTMParaGeogNorte(Convert.ToDouble(numericUpDown7.Value), Convert.ToDouble(numericUpDown8.Value)));

                double este = UTMParaGeogEste(Convert.ToDouble(numericUpDown7.Value), Convert.ToDouble(numericUpDown8.Value));
                if (este < 0)
                {
                    numericUpDown6.Value = Convert.ToDecimal(este * -1);
                    comboBox3.Text = "Oeste";
                }
                if (este >= 0)
                {
                    numericUpDown6.Value = Convert.ToDecimal(este);
                    comboBox3.Text = "Leste";
                }
                comboBox2.Text = comboBox4.Text;                
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown7.ReadOnly = true;
            numericUpDown7.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown7.Increment = 0;
            numericUpDown8.ReadOnly = true;
            numericUpDown8.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown8.Increment = 0;
            numericUpDown9.ReadOnly = true;
            numericUpDown9.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown9.Increment = 0;

            numericUpDown5.ReadOnly = false;
            numericUpDown5.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown5.Increment = 1;
            numericUpDown6.ReadOnly = false;
            numericUpDown6.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown6.Increment = 1;

            comboBox4.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
                
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown7.ReadOnly = false;
            numericUpDown7.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown7.Increment = 1;
            numericUpDown8.ReadOnly = false;
            numericUpDown8.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown8.Increment = 1;
            numericUpDown9.ReadOnly = false;
            numericUpDown9.BackColor = Color.FromArgb(255, 255, 255);
            numericUpDown9.Increment = 1;

            numericUpDown5.ReadOnly = true;
            numericUpDown5.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown5.Increment = 0;
            numericUpDown6.ReadOnly = true;
            numericUpDown6.BackColor = Color.FromArgb(255, 255, 192);
            numericUpDown6.Increment = 0;

            comboBox4.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

        }

























        

    }
}
