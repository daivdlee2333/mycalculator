using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


     
        public double mycalc(string input)
        {
            ICharStream stream = CharStreams.fromstring(input);
            ITokenSource lexer = new LabeledExprLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            LabeledExprParser parser = new LabeledExprParser(tokens);
            parser.BuildParseTree  = true;
            IParseTree tree= parser.expr();

            EvalVisitor eval = new EvalVisitor();
            return eval.Visit(tree);
        }

    private void leftparen(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("(");
        }

        private void rightparen(object sender, RoutedEventArgs e)
        {
            mytext.AppendText(")");
        }

        private void del_clicked(object sender, RoutedEventArgs e)
        {
            mytext.Text = mytext.Text.Substring(0, mytext.Text.Length - 1);
        }

        private void divide_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("/");
        }

        private void seven_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("7");
        }

        private void eight_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("8");
        }

        private void nine_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("9");
        }

        private void multi_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("*");
        }

        private void four_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("4");
        }

        private void six_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("6");
        }

        private void minus_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("-");
        }

        private void five_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("5");
        }

        private void one_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("1");
        }

        private void two_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("2");
        }

        private void three_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("3");
        }

        private void plus_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("+");
        }

        private void clear_clicked(object sender, RoutedEventArgs e)
        {
            mytext.Clear();
        }

        private void dot_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText(".");
        }

        private void zero_clicked(object sender, RoutedEventArgs e)
        {
            mytext.AppendText("0");
        }

        private void equals_clicked(object sender, RoutedEventArgs e)
        {
            result.Content = mycalc(mytext.Text);
        }
    }
}
