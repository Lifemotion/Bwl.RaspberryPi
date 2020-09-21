Public Enum RpiCamFrameType
    bmp
    jpg
End Enum

Public Interface IRpiCam
    Event FrameReady(source As IRpiCam)

    Sub Open()
    Sub Close()

    ReadOnly Property CameraParameters As CameraParameters
    ReadOnly Property FrameCounter As Long
    ReadOnly Property RestartCounter As Integer
    ReadOnly Property FrameBytesBuffer As Byte()
    ReadOnly Property FrameBytesLength As Integer
    ReadOnly Property FrameBytesFormat As RpiCamFrameType
    ReadOnly Property FrameBytesSynclock As Object

    Function CreateBytesCopy() As Byte()

    Sub CaptureOrWaitFrame()

    Sub Reconfigure()
End Interface

