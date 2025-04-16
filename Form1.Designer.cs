using System;
using System.Windows.Forms;

namespace УЛП3._1
{
    public partial class Form1
    {
        private Label resultLabel;
        private Label formulaResultLabel;
        private VScrollBar vScrollBar1;
        private Label label1;

        private void InitializeComponent()
        {
            vScrollBar1 = new VScrollBar();
            label1 = new Label();
            resultLabel = new Label();
            formulaResultLabel = new Label();
            SuspendLayout();
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(770, 10);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(21, 432);
            vScrollBar1.TabIndex = 0;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(348, 96);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 1;
            label1.Text = "n = 1";
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(10, 10);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(64, 20);
            resultLabel.TabIndex = 2;
            resultLabel.Text = "Result: 0";
            // 
            // formulaResultLabel
            // 
            formulaResultLabel.AutoSize = true;
            formulaResultLabel.Location = new Point(10, 40);
            formulaResultLabel.Name = "formulaResultLabel";
            formulaResultLabel.Size = new Size(122, 20);
            formulaResultLabel.TabIndex = 3;
            formulaResultLabel.Text = "Formula Result: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 452);
            Controls.Add(formulaResultLabel);
            Controls.Add(resultLabel);
            Controls.Add(label1);
            Controls.Add(vScrollBar1);
            Name = "Form1";
            Text = "Scrollbar Calculation";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeUI()
        {
            this.vScrollBar1.Minimum = 1;
            this.vScrollBar1.Maximum = 100;
            this.vScrollBar1.Value = 1;
            UpdateResults(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateResults(vScrollBar1.Value);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int n = e.NewValue;
            label1.Text = $"n = {n}";
            UpdateResults(n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = vScrollBar1.Value;
            UpdateResults(n);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optionally, you can add some action here if needed
        }

        private void UpdateResults(int n)
        {
            long result = CalculateByLoop(n);
            double formulaResult = CalculateByFormula(n);

            resultLabel.Text = $"Result: {result}";
            formulaResultLabel.Text = $"Formula Result: {formulaResult}";
        }

        private long CalculateByLoop(int n)
        {
            long result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += (long)Math.Pow(-1, i) * (long)Math.Pow(i, 3);
            }
            return result;
        }

        private double CalculateByFormula(int n)
        {
            return (1.0 / 8.0) * (1 - Math.Pow(-1, n) * (1 - 6 * Math.Pow(n, 2) - 4 * Math.Pow(n, 3)));
        }
    }
}