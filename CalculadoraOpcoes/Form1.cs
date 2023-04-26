namespace CalculadoraOpcoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpa o conteúdo do TextBox
            txtTotal.Clear();
            txtX.Clear();
            txtY.Clear();
            txtTotal.ReadOnly = true;

            //Coloca o foco do Cursor no Txt X
            txtX.Focus();

            //Deixa selecionada a opção Somar
            rdbSomar.Checked = true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Declaração das Variáveis
            double x, y, total;

            //Entrada de Dados
            //Validação de Dados

            //Verifica se o que foi digitado em txtX é número.
            if (!double.TryParse(txtX.Text, out x))
            {
                MessageBox.Show("Informe um valor válido no X", "Calculadora", MessageBoxButtons.OK);
                txtX.Clear();
                txtX.Focus();
                return;
            }

            if (!double.TryParse(txtY.Text, out y))
            {
                MessageBox.Show("Informe um valor válido no Y", "Calculadora", MessageBoxButtons.OK);
                txtY.Clear();
                txtY.Focus();
                return;
            }

            //Processamento
            if (rdbSomar.Checked)
            {
                total = x + y;
                lstHistorico.Items.Add($"Operação: {x} + {y} = {total}");
            }
            else if (rdbSubtrair.Checked)
            {
                total = x - y;
                lstHistorico.Items.Add($"Operação: {x} - {y} = {total}");
            }
            else if (rdbMultiplicar.Checked)
            {
                total = x * y;
                lstHistorico.Items.Add($"Operação: {x} * {y} = {total}");
            }
            else
            {
                //Verifica se está sendo realizada uma divisão por zero
                if (y == 0)
                {
                    txtTotal.Text = "Divisão por 0";
                    return;
                }

                total = x / y;
                lstHistorico.Items.Add($"Operação: {x} / {y} = {total}");
            }

            //Apresenta a saída de dados convertendo para String
            txtTotal.Text = total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}