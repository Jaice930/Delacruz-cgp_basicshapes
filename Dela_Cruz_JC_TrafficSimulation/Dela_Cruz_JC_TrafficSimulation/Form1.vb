Public Class Form1

    Dim state As Integer = 0
    Dim seconds As Integer = 0

    Dim northSouthGreen As Boolean = True
    Dim eastWestGreen As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' TRAFFIC LIGHT TIMER
        TrafficTimer.Interval = 1000
        TrafficTimer.Start()

        ' CAR MOVEMENT TIMER
        CarTimer.Interval = 50
        CarTimer.Start()

        ' INITIAL LIGHTS
        SetNorthSouthGreen()
        SetEastWestRed()

        northSouthGreen = True
        eastWestGreen = False

        ' =====================================================
        ' MOVE CARS TO FORM CONTAINER AND BRING TO FRONT
        ' =====================================================

        MoveCarToForm(pbCar1)
        MoveCarToForm(pbCar2)
        MoveCarToForm(pbCar3)
        MoveCarToForm(pbCar4)
        MoveCarToForm(pbCar5)
        MoveCarToForm(pbCar6)
        MoveCarToForm(pbCar7)
        MoveCarToForm(pbCar8)

        ' =====================================================
        ' BRING TRAFFIC LIGHTS TO FRONT
        ' =====================================================

        pbNorthRed1.BringToFront()
        pbNorthYellow1.BringToFront()
        pbNorthGreen1.BringToFront()

        pbSouthRed1.BringToFront()
        pbSouthYellow1.BringToFront()
        pbSouthGreen1.BringToFront()

        pbEastRed1.BringToFront()
        pbEastYellow1.BringToFront()
        pbEastGreen1.BringToFront()

        pbWestRed1.BringToFront()
        pbWestYellow1.BringToFront()
        pbWestGreen1.BringToFront()



    End Sub


    Private Sub TrafficTimer_Tick(sender As Object, e As EventArgs) Handles TrafficTimer.Tick

        seconds += 1

        If state = 0 Then

            If seconds >= 5 Then

                SetNorthSouthYellow()

                state = 1
                seconds = 0

            End If

        ElseIf state = 1 Then

            If seconds >= 2 Then

                SetNorthSouthRed()
                SetEastWestGreen()
                northSouthGreen = False
                eastWestGreen = True


                state = 2
                seconds = 0

            End If

        ElseIf state = 2 Then

            If seconds >= 5 Then

                SetEastWestYellow()

                state = 3
                seconds = 0

            End If

        ElseIf state = 3 Then

            If seconds >= 2 Then

                SetEastWestRed()
                SetNorthSouthGreen()

                northSouthGreen = True
                eastWestGreen = False

                state = 0
                seconds = 0

            End If

        End If

    End Sub

    ' Intecsection 1

    Private Sub SetNorthSouthGreen()


        pbNorthRed1.Image = My.Resources.off
        pbNorthYellow1.Image = My.Resources.off
        pbNorthGreen1.Image = My.Resources.green

        pbSouthRed1.Image = My.Resources.off
        pbSouthYellow1.Image = My.Resources.off
        pbSouthGreen1.Image = My.Resources.green

        pbNorthRed2.Image = My.Resources.off
        pbNorthYellow2.Image = My.Resources.off
        pbNorthGreen2.Image = My.Resources.green

        pbSouthRed2.Image = My.Resources.off
        pbSouthYellow2.Image = My.Resources.off
        pbSouthGreen2.Image = My.Resources.green

        pbNorthRed3.Image = My.Resources.off
        pbNorthYellow3.Image = My.Resources.off
        pbNorthGreen3.Image = My.Resources.green

        pbSouthRed3.Image = My.Resources.off
        pbSouthYellow3.Image = My.Resources.off
        pbSouthGreen3.Image = My.Resources.green

        pbNorthRed4.Image = My.Resources.off
        pbNorthYellow4.Image = My.Resources.off
        pbNorthGreen4.Image = My.Resources.green

        pbSouthRed4.Image = My.Resources.off
        pbSouthYellow4.Image = My.Resources.off
        pbSouthGreen4.Image = My.Resources.green

    End Sub

    Private Sub SetNorthSouthYellow()

        pbNorthRed1.Image = My.Resources.off
        pbNorthYellow1.Image = My.Resources.yellow
        pbNorthGreen1.Image = My.Resources.off

        pbSouthRed1.Image = My.Resources.off
        pbSouthYellow1.Image = My.Resources.yellow
        pbSouthGreen1.Image = My.Resources.off

        pbNorthRed2.Image = My.Resources.off
        pbNorthYellow2.Image = My.Resources.yellow
        pbNorthGreen2.Image = My.Resources.off

        pbSouthRed2.Image = My.Resources.off
        pbSouthYellow2.Image = My.Resources.yellow
        pbSouthGreen2.Image = My.Resources.off

        pbNorthRed3.Image = My.Resources.off
        pbNorthYellow3.Image = My.Resources.yellow
        pbNorthGreen3.Image = My.Resources.off

        pbSouthRed3.Image = My.Resources.off
        pbSouthYellow3.Image = My.Resources.yellow
        pbSouthGreen3.Image = My.Resources.off

        pbNorthRed4.Image = My.Resources.off
        pbNorthYellow4.Image = My.Resources.yellow
        pbNorthGreen4.Image = My.Resources.off

        pbSouthRed4.Image = My.Resources.off
        pbSouthYellow4.Image = My.Resources.yellow
        pbSouthGreen4.Image = My.Resources.off

    End Sub

    Private Sub SetNorthSouthRed()

        pbNorthRed1.Image = My.Resources.red
        pbNorthYellow1.Image = My.Resources.off
        pbNorthGreen1.Image = My.Resources.off

        pbSouthRed1.Image = My.Resources.red
        pbSouthYellow1.Image = My.Resources.off
        pbSouthGreen1.Image = My.Resources.off

        pbNorthRed2.Image = My.Resources.red
        pbNorthYellow2.Image = My.Resources.off
        pbNorthGreen2.Image = My.Resources.off

        pbSouthRed2.Image = My.Resources.red
        pbSouthYellow2.Image = My.Resources.off
        pbSouthGreen2.Image = My.Resources.off

        pbNorthRed3.Image = My.Resources.red
        pbNorthYellow3.Image = My.Resources.off
        pbNorthGreen3.Image = My.Resources.off

        pbSouthRed3.Image = My.Resources.red
        pbSouthYellow3.Image = My.Resources.off
        pbSouthGreen3.Image = My.Resources.off

        pbNorthRed4.Image = My.Resources.red
        pbNorthYellow4.Image = My.Resources.off
        pbNorthGreen4.Image = My.Resources.off

        pbSouthRed4.Image = My.Resources.red
        pbSouthYellow4.Image = My.Resources.off
        pbSouthGreen4.Image = My.Resources.off

    End Sub

    Private Sub SetEastWestGreen()

        pbEastRed1.Image = My.Resources.off
        pbEastYellow1.Image = My.Resources.off
        pbEastGreen1.Image = My.Resources.green

        pbWestRed1.Image = My.Resources.off
        pbWestYellow1.Image = My.Resources.off
        pbWestGreen1.Image = My.Resources.green

        pbEastRed2.Image = My.Resources.off
        pbEastYellow2.Image = My.Resources.off
        pbEastGreen2.Image = My.Resources.green

        pbWestRed2.Image = My.Resources.off
        pbWestYellow2.Image = My.Resources.off
        pbWestGreen2.Image = My.Resources.green

        pbEastRed3.Image = My.Resources.off
        pbEastYellow3.Image = My.Resources.off
        pbEastGreen3.Image = My.Resources.green

        pbWestRed3.Image = My.Resources.off
        pbWestYellow3.Image = My.Resources.off
        pbWestGreen3.Image = My.Resources.green

        pbEastRed4.Image = My.Resources.off
        pbEastYellow4.Image = My.Resources.off
        pbEastGreen4.Image = My.Resources.green

        pbWestRed4.Image = My.Resources.off
        pbWestYellow4.Image = My.Resources.off
        pbWestGreen4.Image = My.Resources.green

    End Sub

    Private Sub SetEastWestYellow()

        pbEastRed1.Image = My.Resources.off
        pbEastYellow1.Image = My.Resources.yellow
        pbEastGreen1.Image = My.Resources.off

        pbWestRed1.Image = My.Resources.off
        pbWestYellow1.Image = My.Resources.yellow
        pbWestGreen1.Image = My.Resources.off


        pbEastRed2.Image = My.Resources.off
        pbEastYellow2.Image = My.Resources.yellow
        pbEastGreen2.Image = My.Resources.off

        pbWestRed2.Image = My.Resources.off
        pbWestYellow2.Image = My.Resources.yellow
        pbWestGreen2.Image = My.Resources.off

        pbEastRed3.Image = My.Resources.off
        pbEastYellow3.Image = My.Resources.yellow
        pbEastGreen3.Image = My.Resources.off

        pbWestRed3.Image = My.Resources.off
        pbWestYellow3.Image = My.Resources.yellow
        pbWestGreen3.Image = My.Resources.off


        pbEastRed4.Image = My.Resources.off
        pbEastYellow4.Image = My.Resources.yellow
        pbEastGreen4.Image = My.Resources.off

        pbWestRed4.Image = My.Resources.off
        pbWestYellow4.Image = My.Resources.yellow
        pbWestGreen4.Image = My.Resources.off

    End Sub

    Private Sub SetEastWestRed()

        pbEastRed1.Image = My.Resources.red
        pbEastYellow1.Image = My.Resources.off
        pbEastGreen1.Image = My.Resources.off

        pbWestRed1.Image = My.Resources.red
        pbWestYellow1.Image = My.Resources.off
        pbWestGreen1.Image = My.Resources.off

        pbEastRed2.Image = My.Resources.red
        pbEastYellow2.Image = My.Resources.off
        pbEastGreen2.Image = My.Resources.off

        pbWestRed2.Image = My.Resources.red
        pbWestYellow2.Image = My.Resources.off
        pbWestGreen2.Image = My.Resources.off

        pbEastRed3.Image = My.Resources.red
        pbEastYellow3.Image = My.Resources.off
        pbEastGreen3.Image = My.Resources.off

        pbWestRed3.Image = My.Resources.red
        pbWestYellow3.Image = My.Resources.off
        pbWestGreen3.Image = My.Resources.off

        pbEastRed4.Image = My.Resources.red
        pbEastYellow4.Image = My.Resources.off
        pbEastGreen4.Image = My.Resources.off

        pbWestRed4.Image = My.Resources.red
        pbWestYellow4.Image = My.Resources.off
        pbWestGreen4.Image = My.Resources.off

    End Sub

    Private Sub CarTimer_Tick(sender As Object, e As EventArgs) Handles CarTimer.Tick

        pbCar1.BringToFront()
        pbCar2.BringToFront()
        pbCar3.BringToFront()
        pbCar4.BringToFront()
        pbCar5.BringToFront()
        pbCar6.BringToFront()
        pbCar7.BringToFront()
        pbCar8.BringToFront()

        ' =====================================================
        ' pbCar1
        ' =====================================================

        Dim stopCar1 As Boolean = False

        If eastWestGreen = False And pbCar1.Right >= GetFormLeft(stopWest1) And pbCar1.Left < GetFormLeft(stopWest1) Then

            stopCar1 = True

        End If

        If eastWestGreen = False And pbCar1.Right >= GetFormLeft(stopWest2) And pbCar1.Left < GetFormLeft(stopWest2) Then

            stopCar1 = True

        End If

        If stopCar1 = False Then

            pbCar1.Left += 5

        End If

        If pbCar1.Left > Me.Width Then

            pbCar1.Left = -100

        End If

        ' =====================================================
        ' pbCar2 - LEFT TO RIGHT
        ' =====================================================

        Dim stopCar2 As Boolean = False

        If eastWestGreen = False And pbCar2.Right >= GetFormLeft(stopWest3) And pbCar2.Left < GetFormLeft(stopWest3) Then

            stopCar2 = True

        End If

        If eastWestGreen = False And pbCar2.Right >= GetFormLeft(stopWest4) And pbCar2.Left < GetFormLeft(stopWest4) Then

            stopCar2 = True

        End If

        If stopCar2 = False Then

            pbCar2.Left += 5

        End If

        If pbCar2.Left > Me.Width Then

            pbCar2.Left = -100

        End If

        ' =====================================================
        ' pbCar3 - RIGHT TO LEFT
        ' =====================================================

        Dim stopCar3 As Boolean = False

        If eastWestGreen = False And pbCar3.Left <= GetFormRight(stopEast2) And pbCar3.Right > GetFormRight(stopEast2) Then

            stopCar3 = True

        End If

        If eastWestGreen = False And pbCar3.Left <= GetFormRight(stopEast1) And pbCar3.Right > GetFormRight(stopEast1) Then

            stopCar3 = True

        End If

        If stopCar3 = False Then

            pbCar3.Left -= 5

        End If

        If pbCar3.Right < 0 Then

            pbCar3.Left = Me.Width + 100

        End If

        ' =====================================================
        ' pbCar4 - RIGHT TO LEFT
        ' =====================================================

        Dim stopCar4 As Boolean = False

        If eastWestGreen = False And pbCar4.Left <= GetFormRight(stopEast4) And pbCar4.Right > GetFormRight(stopEast4) Then

            stopCar4 = True

        End If

        If eastWestGreen = False And pbCar4.Left <= GetFormRight(stopEast3) And pbCar4.Right > GetFormRight(stopEast3) Then

            stopCar4 = True

        End If

        If stopCar4 = False Then

            pbCar4.Left -= 5

        End If

        If pbCar4.Right < 0 Then

            pbCar4.Left = Me.Width + 100

        End If

        ' =====================================================
        ' pbCar5 - TOP TO BOTTOM
        ' =====================================================

        Dim stopCar5 As Boolean = False

        ' INTERSECTION 1
        If northSouthGreen = False And pbCar5.Bottom >= GetFormTop(stopNorth1) And pbCar5.Top < GetFormTop(stopNorth1) Then

            stopCar5 = True

        End If

        ' INTERSECTION 3
        If northSouthGreen = False And pbCar5.Bottom >= GetFormTop(stopNorth3) And pbCar5.Top < GetFormTop(stopNorth3) Then

            stopCar5 = True

        End If

        ' MOVE
        If stopCar5 = False Then

            pbCar5.Top += 5

        End If

        ' RESET
        If pbCar5.Top > Me.Height Then

            pbCar5.Top = -100

        End If

        ' =====================================================
        ' pbCar6 - TOP TO BOTTOM
        ' =====================================================

        Dim stopCar6 As Boolean = False

        ' INTERSECTION 2
        If northSouthGreen = False And pbCar6.Bottom >= GetFormTop(stopNorth2) And pbCar6.Top < GetFormTop(stopNorth2) Then

            stopCar6 = True

        End If

        ' INTERSECTION 4
        If northSouthGreen = False And pbCar6.Bottom >= GetFormTop(stopNorth4) And pbCar6.Top < GetFormTop(stopNorth4) Then

            stopCar6 = True

        End If

        ' MOVE
        If stopCar6 = False Then

            pbCar6.Top += 5

        End If

        ' RESET
        If pbCar6.Top > Me.Height Then

            pbCar6.Top = -100

        End If

        ' =====================================================
        ' pbCar7 - BOTTOM TO TOP
        ' =====================================================

        Dim stopCar7 As Boolean = False

        ' INTERSECTION 4
        If northSouthGreen = False And pbCar7.Top <= GetFormBottom(stopSouth6) And pbCar7.Bottom > GetFormBottom(stopSouth6) Then

            stopCar7 = True

        End If

        ' INTERSECTION 2
        If northSouthGreen = False And pbCar7.Top <= GetFormBottom(stopSouth5) And pbCar7.Bottom > GetFormBottom(stopSouth5) Then

            stopCar7 = True

        End If

        ' MOVE
        If stopCar7 = False Then

            pbCar7.Top -= 5

        End If

        ' RESET
        If pbCar7.Bottom < 0 Then

            pbCar7.Top = Me.Height + 100

        End If

        ' =====================================================
        ' pbCar8 - BOTTOM TO TOP
        ' =====================================================

        Dim stopCar8 As Boolean = False

        ' INTERSECTION 3
        If northSouthGreen = False And pbCar8.Top <= GetFormBottom(stopSouth3) And pbCar8.Bottom > GetFormBottom(stopSouth3) Then

            stopCar8 = True

        End If

        ' INTERSECTION 1
        If northSouthGreen = False And pbCar8.Top <= GetFormBottom(stopSouth1) And pbCar8.Bottom > GetFormBottom(stopSouth1) Then

            stopCar8 = True

        End If

        ' MOVE
        If stopCar8 = False Then

            pbCar8.Top -= 5

        End If

        ' RESET
        If pbCar8.Bottom < 0 Then

            pbCar8.Top = Me.Height + 100

        End If

    End Sub

    ' =====================================================
    ' COORDINATE CONVERSION AND HELPER METHODS
    ' =====================================================

    Private Function GetFormLeft(ctrl As Control) As Integer
        Dim leftVal As Integer = ctrl.Left
        Dim parentVal As Control = ctrl.Parent
        While parentVal IsNot Nothing AndAlso parentVal IsNot Me
            leftVal += parentVal.Left
            parentVal = parentVal.Parent
        End While
        Return leftVal
    End Function

    Private Function GetFormTop(ctrl As Control) As Integer
        Dim topVal As Integer = ctrl.Top
        Dim parentVal As Control = ctrl.Parent
        While parentVal IsNot Nothing AndAlso parentVal IsNot Me
            topVal += parentVal.Top
            parentVal = parentVal.Parent
        End While
        Return topVal
    End Function

    Private Function GetFormRight(ctrl As Control) As Integer
        Return GetFormLeft(ctrl) + ctrl.Width
    End Function

    Private Function GetFormBottom(ctrl As Control) As Integer
        Return GetFormTop(ctrl) + ctrl.Height
    End Function

    Private Sub MoveCarToForm(car As PictureBox)
        Dim absoluteLeft As Integer = GetFormLeft(car)
        Dim absoluteTop As Integer = GetFormTop(car)
        car.Parent.Controls.Remove(car)
        Me.Controls.Add(car)
        car.Left = absoluteLeft
        car.Top = absoluteTop
        car.BringToFront()
    End Sub

End Class