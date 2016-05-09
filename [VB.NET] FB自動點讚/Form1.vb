
' FB 自動點讚 by SyneArt
' http://art.twgg.org
'
' 版本變更:
' 2013 年 02 月 24 日 - FBAutoLike v1.3 / 增加動態讚與留言讚的按讚選擇 與 狀態顯示方式微調
' 2013 年 02 月 16 日 - FBAutoLike v1.2 / 增加間隔時間控制 與 剩餘時間顯示
' 2013 年 02 月 04 日 - FBAutoLike v1.1 / 增加自動停止時間控制 與 濾除圖片(速度優化)
' 2013 年 02 月 02 日 - FBAutoLike v1.0

Imports System.Threading

Public Class Form1
    Dim urlFBHomePage As String = "http://www.facebook.com/"
    Dim isLike As Boolean, btnOK As Boolean
    Dim stopTime As Date
    Dim remainingTime As String, mytitle As String
    Dim TimeTread As Thread
    Dim intdelayTime As Integer

    ' 使程式完全終止，釋放資源
    Private Sub Form1_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        ' 啟動程式時就瀏覽 Facebook 的首頁
        WebBrowser1.Navigate(urlFBHomePage)
        ' 啟動程式時預設為按讚
        isLike = True
        ' 紀錄目前程式標題
        mytitle = Me.Text
        ' 避免跨執行序呼叫錯誤
        CheckForIllegalCrossThreadCalls = False
        ' 計算時間執行序
        TimeTread = New Thread(AddressOf showTime)
        TimeTread.Start()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' 切換開始/停止 與 按鈕的致能
        Timer1.Enabled = Not Timer1.Enabled
        Button1.Text = IIf(Timer1.Enabled, "停止", "開始")
        RadioButton1.Enabled = IIf(Timer1.Enabled, False, True)
        RadioButton2.Enabled = IIf(Timer1.Enabled, False, True)
        CheckBox1.Enabled = IIf(Timer1.Enabled, False, True)
        CheckBox2.Enabled = IIf(Timer1.Enabled, False, True)
        CheckBox3.Enabled = IIf(Timer1.Enabled, False, True)
        Label2.Enabled = IIf(Timer1.Enabled, False, True)
        NumericUpDown1.Enabled = IIf(Timer1.Enabled, False, True)
        NumericUpDown2.Enabled = IIf(Timer1.Enabled, False, True)

        ' 設定自動停止時間 (如有勾選), 單位:分鐘
        If CheckBox1.Checked Then stopTime = Now.AddMinutes(NumericUpDown1.Value)
        ' 設定執行間隔時間, 單位:秒鐘
        Timer1.Interval = NumericUpDown2.Value * 1000
        ' 設定顯示執行間隔時間
        intdelayTime = NumericUpDown2.Value
        ' 重新整理網頁內容
        WebBrowser1.Refresh()
    End Sub

    ' Timer 預設為 10 秒執行一次
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' 如果網頁已讀取完成
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            Dim doc As HtmlDocument = WebBrowser1.Document
            Dim Element As HtmlElement
            ' 不顯示圖片
            For Each Element In doc.GetElementsByTagName("img")
                Element.OuterHtml = ""
            Next
            For Each Element In doc.All
                ' 判斷 "讚" 或 "收回讚" 的連結 [由 isLike 參數決定]
                If Element.GetAttribute("data-ft").Contains(IIf(isLike, "{""tn"":"">""}", "{""tn"":""?""}")) Then
                    If CheckBox2.Checked And Element.GetAttribute("aria-live").Contains("polite") Then
                        Element.InvokeMember("click") ' 動態讚
                    ElseIf CheckBox3.Checked And Not Element.GetAttribute("aria-live").Contains("polite") Then
                        Element.InvokeMember("click") ' 留言讚
                    ElseIf CheckBox2.Checked And CheckBox3.Checked Then
                        Element.InvokeMember("click") ' 都讚
                    End If
                End If
            Next
            ' 時間到自動停止
            If CheckBox1.Checked And stopTime < Now Then Button1_Click(sender, e)
            ' 將瀏覽器卷軸捲到最底，以讓 FB 讀取新內容
            doc.Window.ScrollTo(0, doc.Body.ScrollRectangle.Height)
            ' 確保延遲時間顯示正確
            intdelayTime = NumericUpDown2.Value
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        ' 由使用者選擇 "讚" 或 "收回讚"
        isLike = IIf(DirectCast((sender), RadioButton).Name = "RadioButton1", True, False)
    End Sub

    ' 判斷是否正在讀取網頁
    Private Sub WebBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            btnOK = True
            Button1.Text = IIf(Timer1.Enabled, "停止", "開始")
        Else
            btnOK = False
            Button1.Text = "等待網頁"
        End If
        CheckBox2a3_CheckedChanged(sender, e)
    End Sub

    ' 顯示目前計算的時間
    Private Sub showTime()
        While True
            Thread.Sleep(1000)
            Application.DoEvents()
            Me.Text = mytitle
            intdelayTime = (intdelayTime + 1) Mod NumericUpDown2.Value
            If Timer1.Enabled Then
                Me.Text &= " (延遲: " & NumericUpDown2.Value - intdelayTime & " 秒"
                Me.Text &= IIf(CheckBox1.Checked, " ，剩餘: " & (Now - stopTime).ToString("mm") & " 分 " & (Now - stopTime).ToString("ss") & " 秒)", ")")
            End If
        End While
    End Sub

    ' 確定目前能不能開始執行
    Private Sub CheckBox2a3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged, CheckBox3.CheckedChanged
        Button1.Enabled = (CheckBox2.Checked Or CheckBox3.Checked) And btnOK
    End Sub
End Class