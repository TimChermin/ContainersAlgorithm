namespace ContainerOpdrachtVersion3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelShipPossible = new System.Windows.Forms.Label();
            this.listBoxContainersNotAddedToShip = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelWeightMiddle = new System.Windows.Forms.Label();
            this.labelMaxWeight = new System.Windows.Forms.Label();
            this.labelMaxWeightDifference = new System.Windows.Forms.Label();
            this.labelWeightDiff = new System.Windows.Forms.Label();
            this.labelMaxWeightUsage = new System.Windows.Forms.Label();
            this.labelWeightTotal = new System.Windows.Forms.Label();
            this.labelWeightRightSide = new System.Windows.Forms.Label();
            this.labelWeightLeftSide = new System.Windows.Forms.Label();
            this.buttonAddContainerToShip = new System.Windows.Forms.Button();
            this.listBoxContainersNotOnShip = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownShipLenght = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownShipWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownShipMaxWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownShipHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddShip = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownContainerWeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownAmountOfContainersToNotOnShip = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonAddContainer = new System.Windows.Forms.Button();
            this.checkBoxCooling = new System.Windows.Forms.CheckBox();
            this.checkBoxValuable = new System.Windows.Forms.CheckBox();
            this.treeViewShip = new System.Windows.Forms.TreeView();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipLenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipMaxWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipHeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownContainerWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountOfContainersToNotOnShip)).BeginInit();
            this.SuspendLayout();
            // 
            // labelShipPossible
            // 
            this.labelShipPossible.AutoSize = true;
            this.labelShipPossible.Location = new System.Drawing.Point(1004, 553);
            this.labelShipPossible.Name = "labelShipPossible";
            this.labelShipPossible.Size = new System.Drawing.Size(144, 17);
            this.labelShipPossible.TabIndex = 44;
            this.labelShipPossible.Text = "Is The Ship Possible: ";
            // 
            // listBoxContainersNotAddedToShip
            // 
            this.listBoxContainersNotAddedToShip.FormattingEnabled = true;
            this.listBoxContainersNotAddedToShip.ItemHeight = 16;
            this.listBoxContainersNotAddedToShip.Location = new System.Drawing.Point(653, 537);
            this.listBoxContainersNotAddedToShip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxContainersNotAddedToShip.Name = "listBoxContainersNotAddedToShip";
            this.listBoxContainersNotAddedToShip.Size = new System.Drawing.Size(321, 228);
            this.listBoxContainersNotAddedToShip.TabIndex = 43;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelWeightMiddle);
            this.groupBox3.Controls.Add(this.labelMaxWeight);
            this.groupBox3.Controls.Add(this.labelMaxWeightDifference);
            this.groupBox3.Controls.Add(this.labelWeightDiff);
            this.groupBox3.Controls.Add(this.labelMaxWeightUsage);
            this.groupBox3.Controls.Add(this.labelWeightTotal);
            this.groupBox3.Controls.Add(this.labelWeightRightSide);
            this.groupBox3.Controls.Add(this.labelWeightLeftSide);
            this.groupBox3.Location = new System.Drawing.Point(1289, 31);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(240, 399);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ship stats";
            // 
            // labelWeightMiddle
            // 
            this.labelWeightMiddle.AutoSize = true;
            this.labelWeightMiddle.Location = new System.Drawing.Point(5, 48);
            this.labelWeightMiddle.Name = "labelWeightMiddle";
            this.labelWeightMiddle.Size = new System.Drawing.Size(101, 17);
            this.labelWeightMiddle.TabIndex = 28;
            this.labelWeightMiddle.Text = "Weight Middle:";
            // 
            // labelMaxWeight
            // 
            this.labelMaxWeight.AutoSize = true;
            this.labelMaxWeight.Location = new System.Drawing.Point(1, 231);
            this.labelMaxWeight.Name = "labelMaxWeight";
            this.labelMaxWeight.Size = new System.Drawing.Size(85, 17);
            this.labelMaxWeight.TabIndex = 27;
            this.labelMaxWeight.Text = "Max Weight:";
            // 
            // labelMaxWeightDifference
            // 
            this.labelMaxWeightDifference.AutoSize = true;
            this.labelMaxWeightDifference.Location = new System.Drawing.Point(5, 123);
            this.labelMaxWeightDifference.Name = "labelMaxWeightDifference";
            this.labelMaxWeightDifference.Size = new System.Drawing.Size(110, 17);
            this.labelMaxWeightDifference.TabIndex = 26;
            this.labelMaxWeightDifference.Text = "Max Weight Diff:";
            // 
            // labelWeightDiff
            // 
            this.labelWeightDiff.AutoSize = true;
            this.labelWeightDiff.Location = new System.Drawing.Point(5, 97);
            this.labelWeightDiff.Name = "labelWeightDiff";
            this.labelWeightDiff.Size = new System.Drawing.Size(125, 17);
            this.labelWeightDiff.TabIndex = 25;
            this.labelWeightDiff.Text = "Weight Difference:";
            // 
            // labelMaxWeightUsage
            // 
            this.labelMaxWeightUsage.AutoSize = true;
            this.labelMaxWeightUsage.Location = new System.Drawing.Point(1, 258);
            this.labelMaxWeightUsage.Name = "labelMaxWeightUsage";
            this.labelMaxWeightUsage.Size = new System.Drawing.Size(130, 17);
            this.labelMaxWeightUsage.TabIndex = 24;
            this.labelMaxWeightUsage.Text = "Max Weight Usage:";
            // 
            // labelWeightTotal
            // 
            this.labelWeightTotal.AutoSize = true;
            this.labelWeightTotal.Location = new System.Drawing.Point(0, 204);
            this.labelWeightTotal.Name = "labelWeightTotal";
            this.labelWeightTotal.Size = new System.Drawing.Size(92, 17);
            this.labelWeightTotal.TabIndex = 23;
            this.labelWeightTotal.Text = "Weight Total:";
            // 
            // labelWeightRightSide
            // 
            this.labelWeightRightSide.AutoSize = true;
            this.labelWeightRightSide.Location = new System.Drawing.Point(5, 70);
            this.labelWeightRightSide.Name = "labelWeightRightSide";
            this.labelWeightRightSide.Size = new System.Drawing.Size(123, 17);
            this.labelWeightRightSide.TabIndex = 22;
            this.labelWeightRightSide.Text = "Weight Right side:";
            // 
            // labelWeightLeftSide
            // 
            this.labelWeightLeftSide.AutoSize = true;
            this.labelWeightLeftSide.Location = new System.Drawing.Point(5, 27);
            this.labelWeightLeftSide.Name = "labelWeightLeftSide";
            this.labelWeightLeftSide.Size = new System.Drawing.Size(114, 17);
            this.labelWeightLeftSide.TabIndex = 21;
            this.labelWeightLeftSide.Text = "Weight Left side:";
            // 
            // buttonAddContainerToShip
            // 
            this.buttonAddContainerToShip.Location = new System.Drawing.Point(722, 289);
            this.buttonAddContainerToShip.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddContainerToShip.Name = "buttonAddContainerToShip";
            this.buttonAddContainerToShip.Size = new System.Drawing.Size(189, 28);
            this.buttonAddContainerToShip.TabIndex = 41;
            this.buttonAddContainerToShip.Text = "Add Containers to Ship";
            this.buttonAddContainerToShip.UseVisualStyleBackColor = true;
            this.buttonAddContainerToShip.Click += new System.EventHandler(this.buttonAddContainerToShip_Click);
            // 
            // listBoxContainersNotOnShip
            // 
            this.listBoxContainersNotOnShip.FormattingEnabled = true;
            this.listBoxContainersNotOnShip.ItemHeight = 16;
            this.listBoxContainersNotOnShip.Location = new System.Drawing.Point(340, 31);
            this.listBoxContainersNotOnShip.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxContainersNotOnShip.Name = "listBoxContainersNotOnShip";
            this.listBoxContainersNotOnShip.Size = new System.Drawing.Size(340, 500);
            this.listBoxContainersNotOnShip.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownShipLenght);
            this.groupBox2.Controls.Add(this.numericUpDownShipWidth);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericUpDownShipMaxWeight);
            this.groupBox2.Controls.Add(this.numericUpDownShipHeight);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonAddShip);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(291, 239);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ship";
            // 
            // numericUpDownShipLenght
            // 
            this.numericUpDownShipLenght.Location = new System.Drawing.Point(135, 22);
            this.numericUpDownShipLenght.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownShipLenght.Name = "numericUpDownShipLenght";
            this.numericUpDownShipLenght.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownShipLenght.TabIndex = 7;
            this.numericUpDownShipLenght.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numericUpDownShipWidth
            // 
            this.numericUpDownShipWidth.Location = new System.Drawing.Point(135, 55);
            this.numericUpDownShipWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownShipWidth.Name = "numericUpDownShipWidth";
            this.numericUpDownShipWidth.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownShipWidth.TabIndex = 8;
            this.numericUpDownShipWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ship Height";
            // 
            // numericUpDownShipMaxWeight
            // 
            this.numericUpDownShipMaxWeight.Location = new System.Drawing.Point(135, 132);
            this.numericUpDownShipMaxWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownShipMaxWeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownShipMaxWeight.Name = "numericUpDownShipMaxWeight";
            this.numericUpDownShipMaxWeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownShipMaxWeight.TabIndex = 9;
            this.numericUpDownShipMaxWeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownShipHeight
            // 
            this.numericUpDownShipHeight.Location = new System.Drawing.Point(135, 91);
            this.numericUpDownShipHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownShipHeight.Name = "numericUpDownShipHeight";
            this.numericUpDownShipHeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownShipHeight.TabIndex = 14;
            this.numericUpDownShipHeight.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ship Lenght";
            // 
            // buttonAddShip
            // 
            this.buttonAddShip.Location = new System.Drawing.Point(135, 170);
            this.buttonAddShip.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddShip.Name = "buttonAddShip";
            this.buttonAddShip.Size = new System.Drawing.Size(120, 28);
            this.buttonAddShip.TabIndex = 13;
            this.buttonAddShip.Text = "Add Ship";
            this.buttonAddShip.UseVisualStyleBackColor = true;
            this.buttonAddShip.Click += new System.EventHandler(this.buttonAddShip_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ship Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ship Max Weight";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownContainerWeight);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDownAmountOfContainersToNotOnShip);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonAddContainer);
            this.groupBox1.Controls.Add(this.checkBoxCooling);
            this.groupBox1.Controls.Add(this.checkBoxValuable);
            this.groupBox1.Location = new System.Drawing.Point(13, 289);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(291, 239);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Containers";
            // 
            // numericUpDownContainerWeight
            // 
            this.numericUpDownContainerWeight.Location = new System.Drawing.Point(136, 31);
            this.numericUpDownContainerWeight.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownContainerWeight.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownContainerWeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownContainerWeight.Name = "numericUpDownContainerWeight";
            this.numericUpDownContainerWeight.Size = new System.Drawing.Size(131, 22);
            this.numericUpDownContainerWeight.TabIndex = 23;
            this.numericUpDownContainerWeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Amount";
            // 
            // numericUpDownAmountOfContainersToNotOnShip
            // 
            this.numericUpDownAmountOfContainersToNotOnShip.Location = new System.Drawing.Point(135, 60);
            this.numericUpDownAmountOfContainersToNotOnShip.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownAmountOfContainersToNotOnShip.Name = "numericUpDownAmountOfContainersToNotOnShip";
            this.numericUpDownAmountOfContainersToNotOnShip.Size = new System.Drawing.Size(133, 22);
            this.numericUpDownAmountOfContainersToNotOnShip.TabIndex = 21;
            this.numericUpDownAmountOfContainersToNotOnShip.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Weight Container";
            // 
            // buttonAddContainer
            // 
            this.buttonAddContainer.Location = new System.Drawing.Point(135, 158);
            this.buttonAddContainer.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddContainer.Name = "buttonAddContainer";
            this.buttonAddContainer.Size = new System.Drawing.Size(132, 28);
            this.buttonAddContainer.TabIndex = 0;
            this.buttonAddContainer.Text = "Add Container";
            this.buttonAddContainer.UseVisualStyleBackColor = true;
            this.buttonAddContainer.Click += new System.EventHandler(this.buttonAddContainer_Click);
            // 
            // checkBoxCooling
            // 
            this.checkBoxCooling.AutoSize = true;
            this.checkBoxCooling.Location = new System.Drawing.Point(135, 98);
            this.checkBoxCooling.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCooling.Name = "checkBoxCooling";
            this.checkBoxCooling.Size = new System.Drawing.Size(77, 21);
            this.checkBoxCooling.TabIndex = 2;
            this.checkBoxCooling.Text = "Cooling";
            this.checkBoxCooling.UseVisualStyleBackColor = true;
            // 
            // checkBoxValuable
            // 
            this.checkBoxValuable.AutoSize = true;
            this.checkBoxValuable.Location = new System.Drawing.Point(135, 132);
            this.checkBoxValuable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxValuable.Name = "checkBoxValuable";
            this.checkBoxValuable.Size = new System.Drawing.Size(85, 21);
            this.checkBoxValuable.TabIndex = 3;
            this.checkBoxValuable.Text = "Valuable";
            this.checkBoxValuable.UseVisualStyleBackColor = true;
            // 
            // treeViewShip
            // 
            this.treeViewShip.Location = new System.Drawing.Point(938, 31);
            this.treeViewShip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeViewShip.Name = "treeViewShip";
            this.treeViewShip.Size = new System.Drawing.Size(344, 500);
            this.treeViewShip.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 839);
            this.Controls.Add(this.labelShipPossible);
            this.Controls.Add(this.listBoxContainersNotAddedToShip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonAddContainerToShip);
            this.Controls.Add(this.listBoxContainersNotOnShip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeViewShip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipLenght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipMaxWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShipHeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownContainerWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountOfContainersToNotOnShip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShipPossible;
        private System.Windows.Forms.ListBox listBoxContainersNotAddedToShip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelWeightMiddle;
        private System.Windows.Forms.Label labelMaxWeight;
        private System.Windows.Forms.Label labelMaxWeightDifference;
        private System.Windows.Forms.Label labelWeightDiff;
        private System.Windows.Forms.Label labelMaxWeightUsage;
        private System.Windows.Forms.Label labelWeightTotal;
        private System.Windows.Forms.Label labelWeightRightSide;
        private System.Windows.Forms.Label labelWeightLeftSide;
        private System.Windows.Forms.Button buttonAddContainerToShip;
        private System.Windows.Forms.ListBox listBoxContainersNotOnShip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownShipLenght;
        private System.Windows.Forms.NumericUpDown numericUpDownShipWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownShipMaxWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownShipHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddShip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownContainerWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownAmountOfContainersToNotOnShip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddContainer;
        private System.Windows.Forms.CheckBox checkBoxCooling;
        private System.Windows.Forms.CheckBox checkBoxValuable;
        private System.Windows.Forms.TreeView treeViewShip;
    }
}

