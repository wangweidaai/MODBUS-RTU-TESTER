Public Class Form1

    Dim _SerialAddress As Byte
    Dim _Param1(1) As Byte
    Dim _Param2(1) As Byte
    Dim ByteCount As Integer = 0
    Dim index As Integer = 0
    Dim bufferTX(100) As Byte
    Dim bufferRX(100) As Byte
    Dim Cmd As String = String.Empty
    Dim RXBYTECOUNT As Integer = 0
    Dim RXBUFFER(100) As Integer
    Dim fMSGRICEVUTO As Boolean = False


    Enum STATUS
        offline
        online
        none
    End Enum

    Dim _status As STATUS



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BAUDRATE.SelectedIndex = 0


        For i As Integer = 13090 To 16226 Step 2 ' Step 64
            Parametro1.Items.Add(Conversion.Hex(i.ToString) + " (TST-EE)")
        Next
        For i As Integer = 16701 To 32637 Step 2 ' Step 64
            Parametro1.Items.Add(Conversion.Hex(i.ToString) + " (TST-FM)")
        Next

        For i As Integer = 12290 To 12626 Step 2
            Parametro1.Items.Add(Conversion.Hex(i.ToString) + " (SET)")
        Next
      
        Parametro1.SelectedIndex = 0

        Timer3.Start()
        Me.COMLIST.DataSource = System.IO.Ports.SerialPort.GetPortNames
       
        fMSGRICEVUTO = False

        _status = STATUS.none

    End Sub



    Private Sub Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Connect.Click
        If Connect.Text = "CONNECT" Then
            If Me.SerialPort1.IsOpen = True Then
                SerialPort1.Close()
                ListBox1.Items.Add("Disconnected from " + SerialPort1.PortName.ToString)
            End If
            SerialPort1.PortName = Me.COMLIST.Text
            SerialPort1.Parity = IO.Ports.Parity.None
            SerialPort1.BaudRate = CInt(Me.BAUDRATE.Text)
            SerialPort1.StopBits = "1"
            SerialPort1.DataBits = "8"
            SerialPort1.Open()
            ' SerialPort1.DiscardInBuffer()
            ' SerialPort1.DiscardOutBuffer()
            If SerialPort1.IsOpen Then
                Connect.Text = "DISCONNECT"
                ListBox1.Items.Add("Connected to " + SerialPort1.PortName.ToString + "(Br:9600 bps, Stop:1, Databits:8)")
                ListBox1.Items.Add("=====================================================")
            End If
        Else
            SerialPort1.Close()
        End If
    End Sub



    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Try
            For index = 0 To SerialPort1.ReceivedBytesThreshold - 1

                bufferRX(index) = SerialPort1.ReadByte()
                'Debug.Print("(" + index.ToString + ") => " + (bufferRX(index).ToString))
            Next
            fMSGRICEVUTO = True
            
        Catch ex As Exception

        End Try


        '  Dim stringaRicevuta As String = (SerialPort1.ReadExisting)
        'Dim bytesRead As Integer = stringaRicevuta.Length
        'For i As Integer = 0 To bytesRead - 1
        '    Dim _byte As Byte = Convert.ToByte(stringaRicevuta(i))

        '    Debug.Print("")

        '    buffer(index) = _byte
        '    index += 1
        'Next

        '' ===== WRITE HOLDING REGISTER (06) --> 8 bytes risposta
        'If Cmd = "06" And index = 8 Then
        '    fMSGRICEVUTO = True
        '    'Cmd = String.Empty
        'End If
        '' ===== WRITE SINGLE COIL (05) --> 8 bytes risposta
        'If Cmd = "05" And RXBYTECOUNT = 7 Then
        '    fMSGRICEVUTO = True
        'End If
        '' ===== READ HOLDING REGISTER (06) --> risposta variabile
        'If Cmd = "03" Then
        '    ' Dim _hex As String = .ToString
        '    Dim totale As Integer = ((Convert.ToInt32(Parametro2.Text, 16)) * 2) + 5
        '    If index = totale Then
        '        fMSGRICEVUTO = True
        '        'Cmd = String.Empty
        '    End If
        'End If



    End Sub



    Public Sub PRINT_BUFFER()
        Try
            If index > 0 Then
                bufferRX(index - 1) = 0
                bufferRX(index - 2) = 0

                REG0.Text = bufferRX(0).ToString
                REG1.Text = bufferRX(1).ToString
                REG2.Text = bufferRX(2).ToString
                REG3.Text = bufferRX(3).ToString
                REG4.Text = bufferRX(4).ToString
                REG5.Text = bufferRX(5).ToString
                REG6.Text = bufferRX(6).ToString
                REG7.Text = bufferRX(7).ToString

                REG8.Text = bufferRX(8).ToString
                REG9.Text = bufferRX(9).ToString
                REG10.Text = bufferRX(10).ToString
                REG11.Text = bufferRX(11).ToString
                REG12.Text = bufferRX(12).ToString
                REG13.Text = bufferRX(13).ToString
                REG14.Text = bufferRX(14).ToString
                REG15.Text = bufferRX(15).ToString

                REG16.Text = bufferRX(16).ToString
                REG17.Text = bufferRX(17).ToString
                REG18.Text = bufferRX(18).ToString
                REG19.Text = bufferRX(19).ToString
                REG20.Text = bufferRX(20).ToString
                REG21.Text = bufferRX(21).ToString
                REG22.Text = bufferRX(22).ToString
                REG23.Text = bufferRX(23).ToString

                REG24.Text = bufferRX(24).ToString
                REG25.Text = bufferRX(25).ToString
                REG26.Text = bufferRX(26).ToString
                REG27.Text = bufferRX(27).ToString
                REG28.Text = bufferRX(28).ToString
                REG29.Text = bufferRX(29).ToString
                REG30.Text = bufferRX(30).ToString
                REG31.Text = bufferRX(31).ToString

                REG32.Text = bufferRX(32).ToString
                REG33.Text = bufferRX(33).ToString
                REG34.Text = bufferRX(34).ToString
                REG35.Text = bufferRX(35).ToString
                REG36.Text = bufferRX(36).ToString
                REG37.Text = bufferRX(37).ToString
                REG38.Text = bufferRX(38).ToString
                REG39.Text = bufferRX(39).ToString

                REG40.Text = bufferRX(40).ToString
                REG41.Text = bufferRX(41).ToString
                REG42.Text = bufferRX(42).ToString
                REG43.Text = bufferRX(43).ToString
                REG44.Text = bufferRX(44).ToString
                REG45.Text = bufferRX(45).ToString
                REG46.Text = bufferRX(46).ToString
                REG47.Text = bufferRX(47).ToString

                REG48.Text = bufferRX(48).ToString
                REG49.Text = bufferRX(49).ToString
                REG50.Text = bufferRX(50).ToString
                REG51.Text = bufferRX(51).ToString
                REG52.Text = bufferRX(52).ToString
                REG53.Text = bufferRX(53).ToString
                REG54.Text = bufferRX(54).ToString
                REG55.Text = bufferRX(55).ToString

                REG56.Text = bufferRX(56).ToString
                REG57.Text = bufferRX(57).ToString
                REG58.Text = bufferRX(58).ToString
                REG59.Text = bufferRX(59).ToString
                REG60.Text = bufferRX(60).ToString
                REG61.Text = bufferRX(61).ToString
                REG62.Text = bufferRX(62).ToString
                REG63.Text = bufferRX(63).ToString


                REG64.Text = bufferRX(64).ToString
                REG65.Text = bufferRX(65).ToString
                REG66.Text = bufferRX(66).ToString
                REG67.Text = bufferRX(67).ToString
                REG68.Text = bufferRX(68).ToString
                REG69.Text = bufferRX(69).ToString

                For Each Item As Object In GroupBox1.Controls

                    Dim _item = Item
                    If (Item.GetType.Name = "Label") Then
                        Dim obj As Label = Item
                        Dim coppie As Integer = Convert.ToInt16(bufferRX(2)) / 2
                        If coppie Mod 2 = 0 Then
                            ' se é pari
                            If (obj.TabIndex - 99) < (2 * coppie) + 3 Then
                                obj.ForeColor = Color.Green
                                obj.Font = New Font(obj.Font, FontStyle.Bold)
                            Else
                                obj.ForeColor = Color.Black
                                obj.Font = New Font(obj.Font, FontStyle.Regular)
                            End If
                        Else
                            ' se é dispari
                            If (obj.TabIndex - 99) < (2 * coppie) + 3 Then
                                obj.ForeColor = Color.Green
                                obj.Font = New Font(obj.Font, FontStyle.Bold)
                            Else
                                obj.ForeColor = Color.Black
                                obj.Font = New Font(obj.Font, FontStyle.Regular)
                            End If
                        End If

                    End If

                Next
            End If
            
        Catch ex As Exception

        End Try
    End Sub



    Public Function C4Char(ByVal tmpStr As String) As String

        Dim tmpstr2 As String = String.Empty

        If tmpStr.Length < 4 Then
            Select Case tmpStr.Length
                Case 0
                    tmpstr2 = "0000"
                Case 1
                    tmpstr2 = "000"
                Case 2
                    tmpstr2 = "00"
                Case 3
                    tmpstr2 = "0"
            End Select
        End If

        C4Char = tmpstr2 & tmpStr

    End Function



    Public Function C5Char(ByVal tmpStr As String) As String

        Dim tmpstr2 As String = String.Empty

        If tmpStr.Length < 5 Then
            Select Case tmpStr.Length
                Case 0
                    tmpstr2 = "00000"
                Case 1
                    tmpstr2 = "0000"
                Case 2
                    tmpstr2 = "000"
                Case 3
                    tmpstr2 = "00"
                Case 4
                    tmpstr2 = "0"
            End Select
        End If

        C5Char = tmpstr2 & tmpStr

    End Function




    Public Function C2Char(ByVal tmpStr As String) As String

        Dim tmpstr2 As String = String.Empty

        If tmpStr.Length < 2 Then
            Select Case tmpStr.Length
                Case 0
                    tmpstr2 = "00"
                Case 1
                    tmpstr2 = "0"
            End Select
        End If

        C2Char = tmpstr2 & tmpStr

    End Function



    Public Function C1Char(ByVal tmpStr As String) As String

        Dim tmpstr2 As String = String.Empty

        If tmpStr.Length < 1 Then
            Select Case tmpStr.Length
               
                Case 1
                    tmpstr2 = "0"
            End Select
        End If

        C1Char = tmpstr2 & tmpStr

    End Function



    Public Function CRC16(ByVal Buffer() As Byte, ByVal length As Integer) As Long
        Dim I As Long
        Dim CRC As Long = &HFFFF
        Dim LSB As Long = 0
        Dim J As Integer
        For I = 0 To length
            CRC = CRC Xor Buffer(I)
            For J = 0 To 7
                LSB = CRC And &H1
                CRC = Math.Floor(CRC / 2)
                If (LSB) Then
                    CRC = (CRC Xor &HA001)
                End If
            Next J
        Next I
        Return CRC
    End Function



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DisableButtons()
        Timer1.Stop()
        Timer2.Start()
        ' 0x05h ( WRITE SINGLE COIL )
        Dim Crc_LBYTE As Long
        Dim Crc_HBYTE As Long
        Dim _crc As Long

        ' === SERIAL ADDRESS ===
        SerialAddress0.Text = C2Char(SerialAddress0.Text)
        _SerialAddress = Convert.ToByte(Convert.ToInt32(SerialAddress0.Text, 16))

        ' === PARAM1 ===
        Dim p1_high As Integer
        Parametro1.Text = C4Char(Parametro1.Text)
        p1_high = (Convert.ToInt32(Parametro1.Text.Substring(0, 2), 16))
        _Param1(0) = Convert.ToByte(p1_high)

        Dim p1_low As Integer
        p1_low = Convert.ToInt32(Parametro1.Text.Substring(2, 2), 16)
        _Param1(1) = Convert.ToByte(p1_low)

        ' === PARAM2 ===
        Dim p2_high As Integer
        Parametro2.Text = C4Char(Parametro2.Text)
        p2_high = (Convert.ToInt32(Parametro2.Text.Substring(0, 2), 16))
        _Param2(0) = Convert.ToByte(p2_high)

        Dim p2_low As Integer
        p2_low = Convert.ToInt32(Parametro2.Text.Substring(2, 2), 16)
        _Param2(1) = Convert.ToByte(p2_low)

        bufferTX(0) = _SerialAddress
        bufferTX(1) = Convert.ToByte("05", 16)
        bufferTX(2) = p1_high
        bufferTX(3) = p1_low
        bufferTX(4) = p2_high
        bufferTX(5) = p2_low
        _crc = CRC16(bufferTX, 5)
        Crc_LBYTE = (_crc And &HFF)
        Crc_HBYTE = (_crc And &HFF00)
        Crc_HBYTE = Crc_HBYTE / 256
        bufferTX(6) = Convert.ToByte(Crc_LBYTE)
        bufferTX(7) = Convert.ToByte(Crc_HBYTE)
        ByteCount = 8
        Cmd = "05"
        index = 0
        Write()
        Timer1.Start()
    End Sub



    Public Sub Write()
        If SerialPort1.IsOpen Then
            ' SerialPort1.DiscardInBuffer()
            ' SerialPort1.DiscardOutBuffer()
            Dim _str As String = String.Empty
            For i As Integer = 0 To ByteCount - 1
                _str += "[" + Conversion.Hex(bufferTX(i)).ToString.ToUpper + "]"
            Next
            ListBox1.Items.Add("TX: " + _str)
            TextBox1.Text = TextBox1.Text + "TX:" + _str + Environment.NewLine


            SerialPort1.DiscardOutBuffer()
            SerialPort1.DiscardInBuffer()

            Select Case Cmd
                Case "03"
                    SerialPort1.ReceivedBytesThreshold = ((Convert.ToInt32(Parametro2.Text, 16)) * 2) + 5
                Case "06", "05"
                    SerialPort1.ReceivedBytesThreshold = ByteCount
                Case Else
                    Debug.Print("")
            End Select
            SerialPort1.Write(bufferTX, 0, ByteCount)
            Timer1.Start()

        Else
            MsgBox("Porta chiusa", MsgBoxStyle.Critical)
        End If
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            _status = STATUS.offline
            ListBox1.Items.Add("RX: TIMEOUT")
            RXBYTECOUNT = 0
            For i As Integer = 0 To bufferRX.Length - 1
                bufferRX(i) = 0
            Next
            PRINT_BUFFER()
            fMSGRICEVUTO = False
            index = 0 'azzero contatore
            Timer1.Stop()
            EnableButtons()
            If Me.RepeatLastCommand.Checked Then
                If Cmd = "03" Then
                    Me.Button3_Click(Nothing, Nothing)
                End If
                If Cmd = "05" Then
                    Me.Button1_Click(Nothing, Nothing)
                End If
                If Cmd = "06" Then
                    Me.Button2_Click(Nothing, Nothing)
                End If


            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If fMSGRICEVUTO Then
                _status = STATUS.online
                EnableButtons()
                Timer2.Stop() 'fermo il timer che aggiorna se é stato ricevuto un frame completo
                Dim _Str As String = String.Empty
                For j As Integer = 0 To index - 1
                    _Str += "[" + (Conversion.Hex((bufferRX(j)))).ToString.ToUpper + "]"
                Next

                PRINT_BUFFER()
                Timer1.Stop()   'fermo il timer per il timeout
                ListBox1.Items.Add("RX: " + _Str)
                TextBox1.Text = TextBox1.Text + "RX:" + _Str + Environment.NewLine
                fMSGRICEVUTO = False
                Array.Clear(bufferRX, 0, bufferRX.Length) ' pulisco buffer
                ListBox1.SelectedIndex = ListBox1.Items.Count - 1
                If Me.RepeatLastCommand.Checked Then
                    If Cmd = "03" Then
                        Me.Button3_Click(Nothing, Nothing)
                    End If
                    If Cmd = "05" Then
                        Me.Button1_Click(Nothing, Nothing)
                    End If
                    If Cmd = "06" Then
                        Me.Button2_Click(Nothing, Nothing)
                    End If


                End If
                index = 0
            End If
        Catch ex As Exception

        End Try
       
    End Sub



    Public Sub EnableButtons()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub



    Public Sub DisableButtons()
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub



    Public Sub GrigliaReadHoldingTST()
        Me.lblreg0.Text = "SADDR"
        Me.lblreg1.Text = "CMD"
        Me.lblreg2.Text = "REG_NUM"
        Me.lblreg3.Text = "0"
        Me.lblreg4.Text = "1"
        Me.lblreg5.Text = "2"
        Me.lblreg6.Text = "3"
        Me.lblreg7.Text = "4"
        Me.lblreg8.Text = "5"
        Me.lblreg9.Text = "6"
        Me.lblreg10.Text = "7"
        Me.lblreg11.Text = "8"
        Me.lblreg12.Text = "9"
        Me.lblreg13.Text = "10"
        Me.lblreg14.Text = "11"
        Me.lblreg15.Text = "12"
        Me.lblreg16.Text = "13"
        Me.lblreg17.Text = "14"
        Me.lblreg18.Text = "15"
        Me.lblreg19.Text = "16"
        Me.lblreg20.Text = "17"
        Me.lblreg21.Text = "18"
        Me.lblreg22.Text = "19"
        Me.lblreg23.Text = "20"
        Me.lblreg24.Text = "21"
        Me.lblreg25.Text = "22"
        Me.lblreg26.Text = "23"
        Me.lblreg27.Text = "24"
        Me.lblreg28.Text = "25"
        Me.lblreg29.Text = "26"
        Me.lblreg30.Text = "27"
        Me.lblreg31.Text = "28"
        Me.lblreg32.Text = "29"
        Me.lblreg33.Text = "30"
        Me.lblreg34.Text = "31"
        Me.lblreg35.Text = "32"
        Me.lblreg36.Text = "33"
        Me.lblreg37.Text = "34"
        Me.lblreg38.Text = "35"
        Me.lblreg39.Text = "36"
        Me.lblreg40.Text = "37"
        Me.lblreg41.Text = "38"
        Me.lblreg42.Text = "39"
        Me.lblreg43.Text = "40"
        Me.lblreg44.Text = "41"
        Me.lblreg45.Text = "42"
        Me.lblreg46.Text = "43"
        Me.lblreg47.Text = "44"
        Me.lblreg48.Text = "45"
        Me.lblreg49.Text = "46"
        Me.lblreg50.Text = "47"
        Me.lblreg51.Text = "48"
        Me.lblreg52.Text = "49"
        Me.lblreg53.Text = "50"
        Me.lblreg54.Text = "51"
        Me.lblreg55.Text = "52"
        Me.lblREG56.Text = "53"
        Me.lblREG57.Text = "54"
        Me.lblREG58.Text = "55"
        Me.lblREG59.Text = "56"
        Me.lblREG60.Text = "57"
        Me.lblREG61.Text = "58"
        Me.lblREG62.Text = "59"
        Me.lblREG63.Text = "60"
        Me.lblreg64.Text = "61"
        Me.lblreg65.Text = "62"
        Me.lblreg66.Text = "63"
        Me.lblreg67.Text = "64"
        Me.lblreg68.Text = "65"
        Me.lblreg69.Text = "66"
        Me.lblreg70.Text = "67"
        Me.lblreg71.Text = "68"

    End Sub


    Public Sub GrigliaReadHoldingSET()
        Me.lblreg0.Text = "SADDR"
        Me.lblreg1.Text = "CMD"
        Me.lblreg2.Text = "REG_NUM"
        Me.lblreg3.Text = "0"
        Me.lblreg4.Text = "1"
        Me.lblreg5.Text = "2"
        Me.lblreg6.Text = "3"
        Me.lblreg7.Text = "4"
        Me.lblreg8.Text = "5"
        Me.lblreg9.Text = "6"
        Me.lblreg10.Text = "7"
        Me.lblreg11.Text = "8"
        Me.lblreg12.Text = "9"
        Me.lblreg13.Text = "10"
        Me.lblreg14.Text = "11"
        Me.lblreg15.Text = "12"
        Me.lblreg16.Text = "13"
        Me.lblreg17.Text = "14"
        Me.lblreg18.Text = "15"
        Me.lblreg19.Text = "16"
        Me.lblreg20.Text = "17"
        Me.lblreg21.Text = "18"
        Me.lblreg22.Text = "19"
        Me.lblreg23.Text = "20"
        Me.lblreg24.Text = "21"
        Me.lblreg25.Text = "22"
        Me.lblreg26.Text = "23"
        Me.lblreg27.Text = "24"
        Me.lblreg28.Text = "25"
        Me.lblreg29.Text = "26"
        Me.lblreg30.Text = "27"
        Me.lblreg31.Text = "28"
        Me.lblreg32.Text = "29"
        Me.lblreg33.Text = "30"
        Me.lblreg34.Text = "31"
        Me.lblreg35.Text = "32"
        Me.lblreg36.Text = "33"
        Me.lblreg37.Text = "34"
        Me.lblreg38.Text = "35"
        Me.lblreg39.Text = "36"
        Me.lblreg40.Text = "37"
        Me.lblreg41.Text = "38"
        Me.lblreg42.Text = "39"
        Me.lblreg43.Text = "40"
        Me.lblreg44.Text = "41"
        Me.lblreg45.Text = "42"
        Me.lblreg46.Text = "43"
        Me.lblreg47.Text = "44"
        Me.lblreg48.Text = "45"
        Me.lblreg49.Text = "46"
        Me.lblreg50.Text = "47"
        Me.lblreg51.Text = "48"
        Me.lblreg52.Text = "49"
        Me.lblreg53.Text = "50"
        Me.lblreg54.Text = "51"
        Me.lblreg55.Text = "52"
        Me.lblREG56.Text = "53"
        Me.lblREG57.Text = "54"
        Me.lblREG58.Text = "55"
        Me.lblREG59.Text = "56"
        Me.lblREG60.Text = "57"
        Me.lblREG61.Text = "58"
        Me.lblREG62.Text = "59"
        Me.lblREG63.Text = "60"
        Me.lblreg64.Text = "61"
        Me.lblreg65.Text = "62"
        Me.lblreg66.Text = "63"
        Me.lblreg67.Text = "64"
        Me.lblreg68.Text = "65"
        Me.lblreg69.Text = "66"
        Me.lblreg70.Text = "67"
        Me.lblreg71.Text = "68"
    End Sub



    Public Sub GrigliaReadHoldingResults()
        Me.lblreg0.Text = "SADDR"
        Me.lblreg1.Text = "CMD"
        Me.lblreg2.Text = "REG_NUM"
        Me.lblreg3.Text = "HOUR_H"
        Me.lblreg4.Text = "HOUR_L"
        Me.lblreg5.Text = "MINUTE_H"
        Me.lblreg6.Text = "MINUTE_L"
        Me.lblreg7.Text = "SECONDS_H"
        Me.lblreg8.Text = "SECONDS_L"
        Me.lblreg9.Text = "DAY_H"
        Me.lblreg10.Text = "DAY_L"
        Me.lblreg11.Text = "MONTH_H"
        Me.lblreg12.Text = "MONTH_L"
        Me.lblreg13.Text = "YEAR_H"
        Me.lblreg14.Text = "YEAR_L"
        Me.lblreg15.Text = "PROG_H"
        Me.lblreg16.Text = "PROG_L"
        Me.lblreg17.Text = "CHAINED_H"
        Me.lblreg18.Text = "CHAINED_L"
        Me.lblreg19.Text = "KIND_OF_TEST_H"
        Me.lblreg20.Text = "KIND_OF_TEST_L"
        Me.lblreg21.Text = "RESULTS_H"
        Me.lblreg22.Text = "RESULTS_L"
        Me.lblreg23.Text = "PHASE_H"
        Me.lblreg24.Text = "PHASE_L"
        Me.lblreg25.Text = "TIME_REM_L2"
        Me.lblreg26.Text = "TIME_REM_L1"
        Me.lblreg27.Text = "TIME_REM_H2"
        Me.lblreg28.Text = "TIME_REM_H1"
        Me.lblreg29.Text = "UM_TIME_H"
        Me.lblreg30.Text = "UM_TIME_L"
        Me.lblreg31.Text = "DEC_PNT_T_L"
        Me.lblreg32.Text = "DEC_PNT_T_H"
        'PRESSIONE MISURATA
        Me.lblreg33.Text = "SIGN_PRESS_H"
        Me.lblreg34.Text = "SIGN_PRESS_L"
        Me.lblreg35.Text = "PRESS_EOT_L2"
        Me.lblreg36.Text = "PRESS_EOT_L1"
        Me.lblreg37.Text = "PRESS_EOT_H2"
        Me.lblreg38.Text = "PRESS_EOT_H1"
        Me.lblreg39.Text = "UM_PRESS_EOT_H"
        Me.lblreg40.Text = "UM_PRESS_EOT_L"
        Me.lblreg41.Text = "DEC_PRESS_EOT_H"
        Me.lblreg42.Text = "DEC_PRESS_EOT_L"
        'VOUT
        Me.lblreg43.Text = "SIGN_DECAY_H"
        Me.lblreg44.Text = "SIGN_DECAY_L"
        Me.lblreg45.Text = "DECAY_EOT_L2"
        Me.lblreg46.Text = "DECAY_EOT_L1"
        Me.lblreg47.Text = "DECAY_EOT_H2"
        Me.lblreg48.Text = "DECAY_EOT_H1"
        Me.lblreg49.Text = "UM_DEC_EOT_H"
        Me.lblreg50.Text = "UM_DEC_EOT_L"
        Me.lblreg51.Text = "DEC_DEC_EOT_H"
        Me.lblreg52.Text = "DEC_DEC_EOT_L"
        'TEMP
        Me.lblreg53.Text = "SIGN_TEMP_H"
        Me.lblreg54.Text = "SIGN_TEMP_L"
        Me.lblreg55.Text = "TEMP_H"
        Me.lblREG56.Text = "TEMP_L"
        Me.lblREG57.Text = "UM_TEMP_H"
        Me.lblREG58.Text = "UM_TEMP_L"
        Me.lblREG59.Text = "PDEC_TEMP_H"
        Me.lblREG60.Text = "PDEC_TEMP_L"
        Me.lblREG61.Text = ""
        Me.lblREG62.Text = ""
        Me.lblREG63.Text = ""
        Me.lblreg64.Text = ""
        Me.lblreg65.Text = ""
        Me.lblreg66.Text = ""
        Me.lblreg67.Text = ""
        Me.lblreg68.Text = ""
        Me.lblreg69.Text = ""
        Me.lblreg70.Text = ""
        Me.lblreg71.Text = ""
    End Sub


    Public Sub GrigliaReadHoldingStatus()
        Me.lblreg0.Text = "SADDR"
        Me.lblreg1.Text = "CMD"
        Me.lblreg2.Text = "REGISTER READ"
        Me.lblreg3.Text = "ERRORMASK_H"
        Me.lblreg4.Text = "ERRORMASK_L"
        Me.lblreg5.Text = "LAST_ACT_STAT_H"
        Me.lblreg6.Text = "LAST_ACT_STAT_L"
        Me.lblreg7.Text = "LAST_ACT_SUBS_H"
        Me.lblreg8.Text = "LAST_ACT_SUBS_L"
        Me.lblreg9.Text = "LAST_ACT_PHAS_H"
        Me.lblreg10.Text = "LAST_ACT_PHAS_L"
        Me.lblreg11.Text = "AUX_H"
        Me.lblreg12.Text = "AUX_L"
        Me.lblreg13.Text = "PROG_H"
        Me.lblreg14.Text = "PROG_L"
        Me.lblreg15.Text = "PENDING_H"
        Me.lblreg16.Text = "PENDING_L"
        Me.lblreg17.Text = "INDEX_MENU_H"
        Me.lblreg18.Text = "INDEX_MENU_L"
        Me.lblreg19.Text = "INDEX_PARAM_H"
        Me.lblreg20.Text = "INDEX_PARAM_L"
        Me.lblreg21.Text = "INDEX_SUBP_H"
        Me.lblreg22.Text = "INDEX_SUBP_L"
        Me.lblreg23.Text = "INDEX_PAR_SUB_H"
        Me.lblreg24.Text = "INDEX_PAR_SUB_L"
        Me.lblreg25.Text = "TIME_REM_L2"
        Me.lblreg26.Text = "TIME_REM_L1"
        Me.lblreg27.Text = "TIME_REM_H2"
        Me.lblreg28.Text = "TIME_REM_H1"
        Me.lblreg29.Text = "UM_TIME_H"
        Me.lblreg30.Text = "UM_TIME_L"
        Me.lblreg31.Text = "DEC_PNT_T_L"
        Me.lblreg32.Text = "DEC_PNT_T_H"
        'PRESSIONE MISURATA
        Me.lblreg33.Text = "SIGN_PRESS_H"
        Me.lblreg34.Text = "SIGN_PRESS_L"
        Me.lblreg35.Text = "PRESS_EOT_L2"
        Me.lblreg36.Text = "PRESS_EOT_L1"
        Me.lblreg37.Text = "PRESS_EOT_H2"
        Me.lblreg38.Text = "PRESS_EOT_H1"
        Me.lblreg39.Text = "UM_PRESS_EOT_H"
        Me.lblreg40.Text = "UM_PRESS_EOT_L"
        Me.lblreg41.Text = "DEC_PRESS_EOT_H"
        Me.lblreg42.Text = "DEC_PRESS_EOT_L"
        'VOUT
        Me.lblreg43.Text = "SIGN_DECAY_H"
        Me.lblreg44.Text = "SIGN_DECAY_L"
        Me.lblreg45.Text = "DECAY_EOT_L2"
        Me.lblreg46.Text = "DECAY_EOT_L1"
        Me.lblreg47.Text = "DECAY_EOT_H2"
        Me.lblreg48.Text = "DECAY_EOT_H1"
        Me.lblreg49.Text = "UM_DEC_EOT_H"
        Me.lblreg50.Text = "UM_DEC_EOT_L"
        Me.lblreg51.Text = "DEC_DEC_EOT_H"
        Me.lblreg52.Text = "DEC_DEC_EOT_L"
        'TEMP
        Me.lblreg53.Text = "SIGN_TEMP_H"
        Me.lblreg54.Text = "SIGN_TEMP_L"
        Me.lblreg55.Text = "TEMP_H"
        Me.lblREG56.Text = "TEMP_L"
        Me.lblREG57.Text = "UM_TEMP_H"
        Me.lblREG58.Text = "UM_TEMP_L"
        Me.lblREG59.Text = "PDEC_TEMP_H"
        Me.lblREG60.Text = "PDEC_TEMP_L"
        Me.lblREG61.Text = "MASK8IN_H"
        Me.lblREG62.Text = "MASK8IN_L"
        Me.lblREG63.Text = "MASK8OUT_H"
        Me.lblreg64.Text = "MASK8OUT_L"
        Me.lblreg65.Text = ""
        Me.lblreg66.Text = ""
        Me.lblreg67.Text = ""
        Me.lblreg68.Text = ""
        Me.lblreg69.Text = ""
        Me.lblreg70.Text = ""
        Me.lblreg71.Text = ""
    End Sub


    Public Sub GrigliaReadHoldingBARCODE()
        Me.lblreg0.Text = "SADDR"
        Me.lblreg1.Text = "CMD"
        Me.lblreg2.Text = "REG_NUM"
        Me.lblreg3.Text = "0"
        Me.lblreg4.Text = "1"
        Me.lblreg5.Text = "2"
        Me.lblreg6.Text = "3"
        Me.lblreg7.Text = "4"
        Me.lblreg8.Text = "5"
        Me.lblreg9.Text = "6"
        Me.lblreg10.Text = "7"
        Me.lblreg11.Text = "8"
        Me.lblreg12.Text = "9"
        Me.lblreg13.Text = "10"
        Me.lblreg14.Text = "11"
        Me.lblreg15.Text = "12"
        Me.lblreg16.Text = "13"
        Me.lblreg17.Text = "14"
        Me.lblreg18.Text = "15"
        Me.lblreg19.Text = "16"
        Me.lblreg20.Text = "17"
        Me.lblreg21.Text = "18"
        Me.lblreg22.Text = "19"
        Me.lblreg23.Text = "20"
        Me.lblreg24.Text = "21"
        Me.lblreg25.Text = "22"
        Me.lblreg26.Text = "23"
        Me.lblreg27.Text = "24"
        Me.lblreg28.Text = "25"
        Me.lblreg29.Text = "26"
        Me.lblreg30.Text = "27"
        Me.lblreg31.Text = "28"
        Me.lblreg32.Text = "29"
        Me.lblreg33.Text = "30"
        Me.lblreg34.Text = "31"
        Me.lblreg35.Text = "32"
        Me.lblreg36.Text = "33"
        Me.lblreg37.Text = "34"
        Me.lblreg38.Text = "35"
        Me.lblreg39.Text = "36"
        Me.lblreg40.Text = "37"
        Me.lblreg41.Text = "38"
        Me.lblreg42.Text = "39"
        Me.lblreg43.Text = "40"
        Me.lblreg44.Text = "41"
        Me.lblreg45.Text = "42"
        Me.lblreg46.Text = "43"
        Me.lblreg47.Text = "44"
        Me.lblreg48.Text = "45"
        Me.lblreg49.Text = "46"
        Me.lblreg50.Text = "47"
        Me.lblreg51.Text = "48"
        Me.lblreg52.Text = "49"
        Me.lblreg53.Text = "50"
        Me.lblreg54.Text = "51"
        Me.lblreg55.Text = "52"
        Me.lblREG56.Text = "53"
        Me.lblREG57.Text = "54"
        Me.lblREG58.Text = "55"
        Me.lblREG59.Text = "56"
        Me.lblREG60.Text = "57"
        Me.lblREG61.Text = "58"
        Me.lblREG62.Text = "59"
        Me.lblREG63.Text = "60"
        Me.lblreg64.Text = "61"
        Me.lblreg65.Text = "62"
        Me.lblreg66.Text = "63"
        Me.lblreg67.Text = "64"
        Me.lblreg68.Text = "65"
        Me.lblreg69.Text = "66"
        Me.lblreg70.Text = "67"
        Me.lblreg71.Text = "68"
    End Sub

    Public Sub GrigliaReadHoldingVERSION()
        Me.lblreg0.Text = "SADDR"
        Me.lblreg1.Text = "CMD"
        Me.lblreg2.Text = "REG_NUM"
        Me.lblreg3.Text = "SN_H2"
        Me.lblreg4.Text = "SN_H1"
        Me.lblreg5.Text = "SN_L2"
        Me.lblreg6.Text = "SN_L1"
        Me.lblreg7.Text = "CHK_FW_H"
        Me.lblreg8.Text = "CHK_FW_L"
        Me.lblreg9.Text = "CHK_BOOT_H"
        Me.lblreg10.Text = "CHK_BOOT_L"
        Me.lblreg11.Text = "MXXXX_H"
        Me.lblreg12.Text = "MXXXX_L"
        Me.lblreg13.Text = "FS1_1_H"
        Me.lblreg14.Text = "FS1_1_L"
        Me.lblreg15.Text = "FS1_2_H"
        Me.lblreg16.Text = "FS1_2_L"
        Me.lblreg17.Text = "FS1_3_H"
        Me.lblreg18.Text = "FS1_3_L"
        Me.lblreg19.Text = "FS2_1_H"
        Me.lblreg20.Text = "FS2_1_L"
        Me.lblreg21.Text = "FS2_2_H"
        Me.lblreg22.Text = "FS2_2_L"
        Me.lblreg23.Text = "FS2_3_H"
        Me.lblreg24.Text = "FS2_3_L"
        Me.lblreg25.Text = "TENSIONEALIM_H"
        Me.lblreg26.Text = "TENSIONEALIM_L"
        Me.lblreg27.Text = "RACCORDERIA_H"
        Me.lblreg28.Text = "RACCORDERIA_L"
        Me.lblreg29.Text = "TIPODIGAS_H"
        Me.lblreg30.Text = "TIPODIGAS_L"
        Me.lblreg31.Text = "PNEU_CONF_H"
        Me.lblreg32.Text = "PNEU_CONF_L"
        Me.lblreg33.Text = "OPT_CONF_H"
        Me.lblreg34.Text = "OPT_CONF_L"
        Me.lblreg35.Text = "MOD_CONF_H"
        Me.lblreg36.Text = "MOD_CONF_L"
        Me.lblreg37.Text = "UM_PRES_CAL_H"
        Me.lblreg38.Text = "UM_PRES_CAL_L"
        Me.lblreg39.Text = "DEC_PRES_CAL_H"
        Me.lblreg40.Text = "DEC_PRES_CAL_L"
        Me.lblreg41.Text = "UM_VOUT_CAL_H"
        Me.lblreg42.Text = "UM_VOUT_CAL_L"
        Me.lblreg43.Text = "DEC_VOUT_CAL_H"
        Me.lblreg44.Text = "DEC_VOUT_CAL_L"
        Me.lblreg45.Text = "UM_VOLUME_H"
        Me.lblreg46.Text = "UM_VOLUME_L"
        Me.lblreg47.Text = "DEC_VOLUME_H"
        Me.lblreg48.Text = "DEC_VOLUME_L"
        Me.lblreg49.Text = "UM_TIME_H"
        Me.lblreg50.Text = "UM_TIME_L"
        Me.lblreg51.Text = "DEC_TIME_H"
        Me.lblreg52.Text = "DEC_TIME_L"
        Me.lblreg53.Text = "UM_P_CAL_SET_H"
        Me.lblreg54.Text = "UM_P_CAL_SET_L"
        Me.lblreg55.Text = "DEC_P_CAL_SET_H"
        Me.lblREG56.Text = "DEC_P_CAL_SET_L"
        Me.lblREG57.Text = "UM_VOUT_SET_H"
        Me.lblREG58.Text = "UM_VOUT_SET_L"
        Me.lblREG59.Text = "DEC_VOUT_SET_H"
        Me.lblREG60.Text = "DEC_VOUT_SET_L"
        Me.lblREG61.Text = "UM_VOL_SET_H"
        Me.lblREG62.Text = "UM_VOL_SET_L"
        Me.lblreg47.Text = "DEC_VOL_SET_H"
        Me.lblreg48.Text = "DEC_VOL_SET_L"
        Me.lblreg49.Text = "UM_TIME_SET_H"
        Me.lblreg50.Text = "UM_TIME_SET_L"
        Me.lblreg51.Text = "DEC_TIME_SET_H"
        Me.lblreg52.Text = "DEC_TIME_SET_L"
        Me.lblreg53.Text = "DIFF_PSET_CAL_H"
        Me.lblreg54.Text = "DIFF_PSET_CAL_L"
        Me.lblreg55.Text = "DIFF_PEVA_CAL_H"
        Me.lblREG56.Text = "DIFF_PEVA_CAL_L"
        Me.lblREG57.Text = "" '"ADDR_TST_H"
        Me.lblREG58.Text = "" '"ADDR_TST_L"
        Me.lblREG59.Text = "" '"ADDR_SET_H"
        Me.lblREG60.Text = "" '"ADDR_SET_L"
        Me.lblREG61.Text = "" '"ADDR_CTP_H"
        Me.lblREG62.Text = "" '"ADDR_CTP_L"
        Me.lblREG63.Text = "" '"ADDR_VER_H"
        Me.lblreg64.Text = "" '"ADDR_VER_L"
        Me.lblreg65.Text = "" '"ADDR_CAL_H"
        Me.lblreg66.Text = "" '"ADDR_CAL_L"
        Me.lblreg67.Text = "" '"INDEX_SUBM_H"
        Me.lblreg68.Text = "" '"INDEX_SUBM_L"
        Me.lblreg69.Text = ""
        Me.lblreg70.Text = ""
        Me.lblreg71.Text = ""
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DisableButtons()
        If C4Char(Parametro1.Text).Contains("0030") Then
            GrigliaReadHoldingStatus()
        End If
        If C4Char(Parametro1.Text).Contains("0040") Then
            GrigliaReadHoldingResults()
        End If
        If C4Char(Parametro1.Text).Contains("0050") Then
            GrigliaReadHoldingVERSION()
        End If
        If C4Char(Parametro1.Text).Contains("0060") Then
            GrigliaReadHoldingBARCODE()
        End If


        If Parametro1.Text.Contains("TST") Then
            GrigliaReadHoldingTST()
        End If
        If Parametro1.Text.Contains("SET") Then
            GrigliaReadHoldingSET()
        End If

        Timer1.Stop() 'fermo il timeout
        Timer2.Start() 'faccio partire il timer che controlla ciclicamente se il messaggio é completo

        ' 0x03h ( READ HOLDING REGISTERS )
        Dim Crc_LBYTE As Long
        Dim Crc_HBYTE As Long
        Dim _crc As Long

        ' === SERIAL ADDRESS ===
        SerialAddress0.Text = C2Char(SerialAddress0.Text)
        _SerialAddress = Convert.ToByte(Convert.ToInt32(SerialAddress0.Text, 16))

        ' === PARAM1 ===
        Dim p1_high As Integer
        Parametro1.Text = C4Char(Parametro1.Text)
        p1_high = (Convert.ToInt32(Parametro1.Text.Substring(0, 2), 16))
        _Param1(0) = Convert.ToByte(p1_high)

        Dim p1_low As Integer
        p1_low = Convert.ToInt32(Parametro1.Text.Substring(2, 2), 16)
        _Param1(1) = Convert.ToByte(p1_low)

        ' === PARAM2 ===
        Dim p2_high As Integer
        Parametro2.Text = C4Char(Parametro2.Text)
        p2_high = (Convert.ToInt32(Parametro2.Text.Substring(0, 2), 16))
        _Param2(0) = Convert.ToByte(p2_high)

        Dim p2_low As Integer
        p2_low = Convert.ToInt32(Parametro2.Text.Substring(2, 2), 16)
        _Param2(1) = Convert.ToByte(p2_low)

        bufferTX(0) = _SerialAddress
        bufferTX(1) = Convert.ToByte("03", 16)
        bufferTX(2) = p1_high
        bufferTX(3) = p1_low
        bufferTX(4) = p2_high
        bufferTX(5) = p2_low
        'bufferTX(2) = 51
        'bufferTX(3) = 34
        'bufferTX(4) = 0
        'bufferTX(5) = 32

        _crc = CRC16(bufferTX, 5)
        Crc_LBYTE = (_crc And &HFF)
        Crc_HBYTE = (_crc And &HFF00)
        Crc_HBYTE = Crc_HBYTE / 256
        bufferTX(6) = Convert.ToByte(Crc_LBYTE)
        bufferTX(7) = Convert.ToByte(Crc_HBYTE)
        ByteCount = 8
        Cmd = "03"
        index = 0
        Write()
        Timer1.Start() 'faccio partire il timer

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        fMSGRICEVUTO = False
        DisableButtons()
        Timer1.Stop()
        Timer2.Start()
        ' 0x06h ( WRITE SINGLE REGISTER )
        Dim Crc_LBYTE As Long
        Dim Crc_HBYTE As Long
        Dim _crc As Long

        ' === SERIAL ADDRESS ===
        SerialAddress0.Text = C2Char(SerialAddress0.Text)
        _SerialAddress = Convert.ToByte(Convert.ToInt32(SerialAddress0.Text, 16))

        ' === PARAM1 ===
        Dim p1_high As Integer
        Parametro1.Text = C4Char(Parametro1.Text)
        p1_high = (Convert.ToInt32(Parametro1.Text.Substring(0, 2), 16))
        _Param1(0) = Convert.ToByte(p1_high)

        Dim p1_low As Integer
        p1_low = Convert.ToInt32(Parametro1.Text.Substring(2, 2), 16)
        _Param1(1) = Convert.ToByte(p1_low)

        ' === PARAM2 ===
        Dim p2_high As Integer
        Parametro2.Text = C4Char(Parametro2.Text)
        p2_high = (Convert.ToInt32(Parametro2.Text.Substring(0, 2), 16))
        _Param2(0) = Convert.ToByte(p2_high)

        Dim p2_low As Integer
        p2_low = Convert.ToInt32(Parametro2.Text.Substring(2, 2), 16)
        _Param2(1) = Convert.ToByte(p2_low)

        index = 0
        bufferTX(0) = _SerialAddress
        bufferTX(1) = Convert.ToByte("06", 16)
        bufferTX(2) = p1_high
        bufferTX(3) = p1_low
        bufferTX(4) = p2_high
        bufferTX(5) = p2_low
        _crc = CRC16(bufferTX, 5)
        Crc_LBYTE = (_crc And &HFF)
        Crc_HBYTE = (_crc And &HFF00)
        Crc_HBYTE = Crc_HBYTE / 256
        bufferTX(6) = Convert.ToByte(Crc_LBYTE)
        bufferTX(7) = Convert.ToByte(Crc_HBYTE)
        ByteCount = 8
        Cmd = "06"
        Write()
        Timer1.Start()
    End Sub



    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Try
            If _status = STATUS.none Then
                PictureBox1.Image = My.Resources.BIANCO
            End If
            If _status = STATUS.offline Then
                PictureBox1.Image = My.Resources.ROSSO
            End If
            If _status = STATUS.online Then
                PictureBox1.Image = My.Resources.VERDE
            End If
        Catch ex As Exception

        End Try


    End Sub



    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        With Me.TextBox1
            .SelectionStart = Len(.Text)
            .ScrollToCaret()
        End With
    End Sub


    'Private Sub REG25_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REG25.TextChanged, REG26.TextChanged, REG28.TextChanged
    '    'If REG25.Text <> String.Empty And REG26.Text <> String.Empty And REG27.Text <> String.Empty Then
    '    '    Label8.Text = CInt(REG26.Text) + 256 * (CInt(REG25.Text)) + 65536 * (CInt(REG28.Text))
    '    'End If


    'End Sub

   
End Class
