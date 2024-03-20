namespace HelloCSharp002_5
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.scissors = new System.Windows.Forms.Button();
            this.th1 = new System.Windows.Forms.Label();
            this.rNum = new System.Windows.Forms.Label();
            this.th2 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.rock = new System.Windows.Forms.Button();
            this.paper = new System.Windows.Forms.Button();
            this.th0 = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scissors
            // 
            this.scissors.Location = new System.Drawing.Point(16, 40);
            this.scissors.Name = "scissors";
            this.scissors.Size = new System.Drawing.Size(50, 29);
            this.scissors.TabIndex = 0;
            this.scissors.Text = "가위";
            this.scissors.UseVisualStyleBackColor = true;
            this.scissors.Click += new System.EventHandler(this.scissors_Click);
            // 
            // th1
            // 
            this.th1.AutoSize = true;
            this.th1.Location = new System.Drawing.Point(407, 20);
            this.th1.Name = "th1";
            this.th1.Size = new System.Drawing.Size(69, 12);
            this.th1.TabIndex = 2;
            this.th1.Text = "컴퓨터 결과";
            // 
            // rNum
            // 
            this.rNum.AutoSize = true;
            this.rNum.Location = new System.Drawing.Point(407, 57);
            this.rNum.Name = "rNum";
            this.rNum.Size = new System.Drawing.Size(41, 12);
            this.rNum.TabIndex = 4;
            this.rNum.Text = "랜덤값";
            // 
            // th2
            // 
            this.th2.AutoSize = true;
            this.th2.Location = new System.Drawing.Point(521, 20);
            this.th2.Name = "th2";
            this.th2.Size = new System.Drawing.Size(29, 12);
            this.th2.TabIndex = 5;
            this.th2.Text = "결과";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(521, 57);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(53, 12);
            this.result.TabIndex = 6;
            this.result.Text = "정답결과";
            // 
            // rock
            // 
            this.rock.Location = new System.Drawing.Point(99, 40);
            this.rock.Name = "rock";
            this.rock.Size = new System.Drawing.Size(50, 29);
            this.rock.TabIndex = 7;
            this.rock.Text = "바위";
            this.rock.UseVisualStyleBackColor = true;
            this.rock.Click += new System.EventHandler(this.rock_Click);
            // 
            // paper
            // 
            this.paper.Location = new System.Drawing.Point(181, 40);
            this.paper.Name = "paper";
            this.paper.Size = new System.Drawing.Size(50, 29);
            this.paper.TabIndex = 8;
            this.paper.Text = "보";
            this.paper.UseVisualStyleBackColor = true;
            this.paper.Click += new System.EventHandler(this.paper_Click);
            // 
            // th0
            // 
            this.th0.AutoSize = true;
            this.th0.Location = new System.Drawing.Point(41, 11);
            this.th0.Name = "th0";
            this.th0.Size = new System.Drawing.Size(97, 12);
            this.th0.TabIndex = 9;
            this.th0.Text = "현재 나의 선택 : ";
            // 
            // select
            // 
            this.select.AutoSize = true;
            this.select.Location = new System.Drawing.Point(153, 11);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(41, 12);
            this.select.TabIndex = 10;
            this.select.Text = "선택값";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(280, 20);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(67, 57);
            this.submit.TabIndex = 11;
            this.submit.Text = "제출";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 89);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.select);
            this.Controls.Add(this.th0);
            this.Controls.Add(this.paper);
            this.Controls.Add(this.rock);
            this.Controls.Add(this.result);
            this.Controls.Add(this.th2);
            this.Controls.Add(this.rNum);
            this.Controls.Add(this.th1);
            this.Controls.Add(this.scissors);
            this.Name = "Form1";
            this.Text = "가위바위보 게임";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scissors;
        private System.Windows.Forms.Label th1;
        private System.Windows.Forms.Label rNum;
        private System.Windows.Forms.Label th2;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button rock;
        private System.Windows.Forms.Button paper;
        private System.Windows.Forms.Label th0;
        private System.Windows.Forms.Label select;
        private System.Windows.Forms.Button submit;
    }
}

