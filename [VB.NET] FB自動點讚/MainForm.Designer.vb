<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MyWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.MainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonStartAction = New System.Windows.Forms.Button()
        Me.RadioButtonTypePressLike = New System.Windows.Forms.RadioButton()
        Me.RadioButtonTypePressUnLike = New System.Windows.Forms.RadioButton()
        Me.CheckBoxEnableLimitTime = New System.Windows.Forms.CheckBox()
        Me.NumericUpDownLimitTime = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownDelayTime = New System.Windows.Forms.NumericUpDown()
        Me.LabelShowTimeText = New System.Windows.Forms.Label()
        Me.CheckBoxChooseTypeFeed = New System.Windows.Forms.CheckBox()
        Me.CheckBoxChooseTypeComment = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxChooseTypeReply = New System.Windows.Forms.CheckBox()
        CType(Me.NumericUpDownLimitTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownDelayTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyWebBrowser
        '
        Me.MyWebBrowser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyWebBrowser.Location = New System.Drawing.Point(0, 32)
        Me.MyWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.MyWebBrowser.Name = "MyWebBrowser"
        Me.MyWebBrowser.ScriptErrorsSuppressed = True
        Me.MyWebBrowser.Size = New System.Drawing.Size(748, 433)
        Me.MyWebBrowser.TabIndex = 0
        '
        'MainTimer
        '
        Me.MainTimer.Interval = 3000
        '
        'ButtonStartAction
        '
        Me.ButtonStartAction.Location = New System.Drawing.Point(12, 4)
        Me.ButtonStartAction.Name = "ButtonStartAction"
        Me.ButtonStartAction.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStartAction.TabIndex = 1
        Me.ButtonStartAction.Text = "開始"
        Me.ButtonStartAction.UseVisualStyleBackColor = True
        '
        'RadioButtonTypePressLike
        '
        Me.RadioButtonTypePressLike.AutoSize = True
        Me.RadioButtonTypePressLike.Checked = True
        Me.RadioButtonTypePressLike.Location = New System.Drawing.Point(110, 8)
        Me.RadioButtonTypePressLike.Name = "RadioButtonTypePressLike"
        Me.RadioButtonTypePressLike.Size = New System.Drawing.Size(35, 16)
        Me.RadioButtonTypePressLike.TabIndex = 3
        Me.RadioButtonTypePressLike.TabStop = True
        Me.RadioButtonTypePressLike.Text = "讚"
        Me.RadioButtonTypePressLike.UseVisualStyleBackColor = True
        '
        'RadioButtonTypePressUnLike
        '
        Me.RadioButtonTypePressUnLike.AutoSize = True
        Me.RadioButtonTypePressUnLike.Location = New System.Drawing.Point(149, 8)
        Me.RadioButtonTypePressUnLike.Name = "RadioButtonTypePressUnLike"
        Me.RadioButtonTypePressUnLike.Size = New System.Drawing.Size(59, 16)
        Me.RadioButtonTypePressUnLike.TabIndex = 4
        Me.RadioButtonTypePressUnLike.Text = "收回讚"
        Me.RadioButtonTypePressUnLike.UseVisualStyleBackColor = True
        '
        'CheckBoxEnableLimitTime
        '
        Me.CheckBoxEnableLimitTime.AutoSize = True
        Me.CheckBoxEnableLimitTime.Location = New System.Drawing.Point(567, 8)
        Me.CheckBoxEnableLimitTime.Name = "CheckBoxEnableLimitTime"
        Me.CheckBoxEnableLimitTime.Size = New System.Drawing.Size(156, 16)
        Me.CheckBoxEnableLimitTime.TabIndex = 6
        Me.CheckBoxEnableLimitTime.Text = "於　　　　　分鐘後停止"
        Me.CheckBoxEnableLimitTime.UseVisualStyleBackColor = True
        '
        'NumericUpDownLimitTime
        '
        Me.NumericUpDownLimitTime.Location = New System.Drawing.Point(602, 5)
        Me.NumericUpDownLimitTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownLimitTime.Name = "NumericUpDownLimitTime"
        Me.NumericUpDownLimitTime.Size = New System.Drawing.Size(52, 22)
        Me.NumericUpDownLimitTime.TabIndex = 7
        Me.NumericUpDownLimitTime.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'NumericUpDownDelayTime
        '
        Me.NumericUpDownDelayTime.Location = New System.Drawing.Point(471, 5)
        Me.NumericUpDownDelayTime.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDownDelayTime.Name = "NumericUpDownDelayTime"
        Me.NumericUpDownDelayTime.Size = New System.Drawing.Size(52, 22)
        Me.NumericUpDownDelayTime.TabIndex = 9
        Me.NumericUpDownDelayTime.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'LabelShowTimeText
        '
        Me.LabelShowTimeText.AutoSize = True
        Me.LabelShowTimeText.Location = New System.Drawing.Point(417, 8)
        Me.LabelShowTimeText.Name = "LabelShowTimeText"
        Me.LabelShowTimeText.Size = New System.Drawing.Size(149, 12)
        Me.LabelShowTimeText.TabIndex = 10
        Me.LabelShowTimeText.Text = "執行間隔　　　　　秒鐘，"
        '
        'CheckBoxChooseTypeFeed
        '
        Me.CheckBoxChooseTypeFeed.AutoSize = True
        Me.CheckBoxChooseTypeFeed.Checked = True
        Me.CheckBoxChooseTypeFeed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxChooseTypeFeed.Location = New System.Drawing.Point(5, 13)
        Me.CheckBoxChooseTypeFeed.Name = "CheckBoxChooseTypeFeed"
        Me.CheckBoxChooseTypeFeed.Size = New System.Drawing.Size(60, 16)
        Me.CheckBoxChooseTypeFeed.TabIndex = 11
        Me.CheckBoxChooseTypeFeed.Text = "動態讚"
        Me.CheckBoxChooseTypeFeed.UseVisualStyleBackColor = True
        '
        'CheckBoxChooseTypeComment
        '
        Me.CheckBoxChooseTypeComment.AutoSize = True
        Me.CheckBoxChooseTypeComment.Checked = True
        Me.CheckBoxChooseTypeComment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxChooseTypeComment.Location = New System.Drawing.Point(63, 13)
        Me.CheckBoxChooseTypeComment.Name = "CheckBoxChooseTypeComment"
        Me.CheckBoxChooseTypeComment.Size = New System.Drawing.Size(60, 16)
        Me.CheckBoxChooseTypeComment.TabIndex = 12
        Me.CheckBoxChooseTypeComment.Text = "留言讚"
        Me.CheckBoxChooseTypeComment.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxChooseTypeReply)
        Me.GroupBox1.Controls.Add(Me.CheckBoxChooseTypeComment)
        Me.GroupBox1.Controls.Add(Me.CheckBoxChooseTypeFeed)
        Me.GroupBox1.Location = New System.Drawing.Point(210, -5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 33)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'CheckBoxChooseTypeReply
        '
        Me.CheckBoxChooseTypeReply.AutoSize = True
        Me.CheckBoxChooseTypeReply.Checked = True
        Me.CheckBoxChooseTypeReply.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxChooseTypeReply.Location = New System.Drawing.Point(121, 13)
        Me.CheckBoxChooseTypeReply.Name = "CheckBoxChooseTypeReply"
        Me.CheckBoxChooseTypeReply.Size = New System.Drawing.Size(60, 16)
        Me.CheckBoxChooseTypeReply.TabIndex = 13
        Me.CheckBoxChooseTypeReply.Text = "回覆讚"
        Me.CheckBoxChooseTypeReply.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 465)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.NumericUpDownDelayTime)
        Me.Controls.Add(Me.LabelShowTimeText)
        Me.Controls.Add(Me.NumericUpDownLimitTime)
        Me.Controls.Add(Me.CheckBoxEnableLimitTime)
        Me.Controls.Add(Me.RadioButtonTypePressUnLike)
        Me.Controls.Add(Me.RadioButtonTypePressLike)
        Me.Controls.Add(Me.ButtonStartAction)
        Me.Controls.Add(Me.MyWebBrowser)
        Me.Name = "MainForm"
        Me.Text = "FB 自動點讚 v1.4 By SyneArt"
        CType(Me.NumericUpDownLimitTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownDelayTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MyWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents MainTimer As System.Windows.Forms.Timer
    Friend WithEvents ButtonStartAction As System.Windows.Forms.Button
    Friend WithEvents RadioButtonTypePressLike As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTypePressUnLike As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxEnableLimitTime As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDownLimitTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownDelayTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelShowTimeText As System.Windows.Forms.Label
    Friend WithEvents CheckBoxChooseTypeFeed As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxChooseTypeComment As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxChooseTypeReply As System.Windows.Forms.CheckBox

End Class
