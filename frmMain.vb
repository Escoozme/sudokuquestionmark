Public Class frmMain
    Dim focusedLabel As Object
    Dim groups(8, 8) As Object
    Dim rowsColumns(,) As Object

    Private Function FindRowIndex() As Integer
        Dim intNum As Integer = 0

        For r As Integer = 0 To 8
            For c As Integer = 0 To 8
                If rowsColumns(r, c).Text = focusedLabel.Text Then
                    intNum = r
                    r = 9
                    Exit For
                End If
            Next
        Next

        Return intNum
    End Function

    'Enters number into focusedLabel
    'If number already exists in group, doesn't enter number
    'IsNothing function covers for error if number is clicked without any labels focused
    Private Sub NumberButton_Click(sender As Object, e As EventArgs) Handles btnOne.Click, btnTwo.Click, btnThree.Click, btnFour.Click,
                                                                             btnFive.Click, btnSix.Click, btnSeven.Click, btnEight.Click, btnNine.Click
        Dim labelTaken As Boolean = False

        If Not IsNothing(focusedLabel) Then
            Dim intGrpNum As Integer
            Integer.TryParse(focusedLabel.Name(3), intGrpNum)
            intGrpNum -= 1

            'Check group for number
            For intNum As Integer = 0 To 8
                If groups(intGrpNum, intNum).Text = sender.Text Then
                    labelTaken = True
                    Exit For
                End If
            Next

            'Check rows and columns for number
            Dim row As Integer = FindRowIndex()
            For column As Integer = 0 To 8
                If rowsColumns(row, column).Text = sender.Text Then
                    labelTaken = True
                    Exit For
                End If
            Next

            If labelTaken = False Then
                focusedLabel.Text = sender.Text
            End If
        End If
    End Sub

    'Focuses label, shows visually that label is selected
    'Sets global focusedLabel object to selected label to be used for entering numbers or erasing
    'IsNothing function covers for error if label is clicked without any other labels focused
    Private Sub Grp_Click(sender As Object, e As EventArgs) Handles lbl1_1.Click, lbl1_2.Click, lbl1_3.Click, lbl1_4.Click, lbl1_5.Click, lbl1_6.Click, lbl1_7.Click, lbl1_8.Click, lbl1_9.Click,
                                                                    lbl2_1.Click, lbl2_2.Click, lbl2_3.Click, lbl2_4.Click, lbl2_5.Click, lbl2_6.Click, lbl2_7.Click, lbl2_8.Click, lbl2_9.Click,
                                                                    lbl3_1.Click, lbl3_2.Click, lbl3_3.Click, lbl3_4.Click, lbl3_5.Click, lbl3_6.Click, lbl3_7.Click, lbl3_8.Click, lbl3_9.Click,
                                                                    lbl4_1.Click, lbl4_2.Click, lbl4_3.Click, lbl4_4.Click, lbl4_5.Click, lbl4_6.Click, lbl4_7.Click, lbl4_8.Click, lbl4_9.Click,
                                                                    lbl5_1.Click, lbl5_2.Click, lbl5_3.Click, lbl5_4.Click, lbl5_5.Click, lbl5_6.Click, lbl5_7.Click, lbl5_8.Click, lbl5_9.Click,
                                                                    lbl6_1.Click, lbl6_2.Click, lbl6_3.Click, lbl6_4.Click, lbl6_5.Click, lbl6_6.Click, lbl6_7.Click, lbl6_8.Click, lbl6_9.Click,
                                                                    lbl7_1.Click, lbl7_2.Click, lbl7_3.Click, lbl7_4.Click, lbl7_5.Click, lbl7_6.Click, lbl7_7.Click, lbl7_8.Click, lbl7_9.Click,
                                                                    lbl8_1.Click, lbl8_2.Click, lbl8_3.Click, lbl8_4.Click, lbl8_5.Click, lbl8_6.Click, lbl8_7.Click, lbl8_8.Click, lbl8_9.Click,
                                                                    lbl9_1.Click, lbl9_2.Click, lbl9_3.Click, lbl9_4.Click, lbl9_5.Click, lbl9_6.Click, lbl9_7.Click, lbl9_8.Click, lbl9_9.Click

        If Not IsNothing(focusedLabel) Then
            focusedLabel.BorderStyle = BorderStyle.FixedSingle
        End If

        sender.Focus()
        sender.BorderStyle = BorderStyle.Fixed3D
        focusedLabel = sender
    End Sub

    'Populates group arrays with respective 9 grouped boxes
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim groupBoxArray() As Object = {grp1, grp2, grp3, grp4, grp5, grp6, grp7, grp8, grp9}

        For r As Integer = 0 To 8
            ActiveControl = groupBoxArray(r)
            For c As Integer = 0 To 8
                groups(r, c) = GetNextControl(ActiveControl, True)
                ActiveControl = GetNextControl(ActiveControl, True)
            Next
        Next

        rowsColumns = {{lbl1_1, lbl1_2, lbl1_3, lbl2_1, lbl2_2, lbl2_3, lbl3_1, lbl3_2, lbl3_3},
                       {lbl1_4, lbl1_5, lbl1_6, lbl2_4, lbl2_5, lbl2_6, lbl3_4, lbl3_5, lbl3_6},
                       {lbl1_7, lbl1_8, lbl1_9, lbl2_7, lbl2_8, lbl2_9, lbl3_7, lbl3_8, lbl3_9},
                       {lbl4_1, lbl4_2, lbl4_3, lbl5_1, lbl5_2, lbl5_3, lbl6_1, lbl6_2, lbl6_3},
                       {lbl4_4, lbl4_5, lbl4_6, lbl5_4, lbl5_5, lbl5_6, lbl6_4, lbl6_5, lbl6_6},
                       {lbl4_7, lbl4_8, lbl4_9, lbl5_7, lbl5_8, lbl5_9, lbl6_7, lbl6_8, lbl6_9},
                       {lbl7_1, lbl7_2, lbl7_3, lbl8_1, lbl8_2, lbl8_3, lbl9_1, lbl9_2, lbl9_3},
                       {lbl7_4, lbl7_5, lbl7_6, lbl8_4, lbl8_5, lbl8_6, lbl9_4, lbl9_5, lbl9_6},
                       {lbl7_7, lbl7_8, lbl7_9, lbl8_7, lbl8_8, lbl8_9, lbl9_7, lbl9_8, lbl9_9}}
    End Sub

    'Clears focused label of number(s)
    'IsNothing function covers for error if eraser is clicked without any labels focused
    Private Sub btnEraser_Click(sender As Object, e As EventArgs) Handles btnEraser.Click
        If Not IsNothing(focusedLabel) Then
            focusedLabel.Text = String.Empty
        End If
    End Sub
End Class
