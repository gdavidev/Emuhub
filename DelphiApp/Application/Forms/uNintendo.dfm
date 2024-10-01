object formNintendo: TformNintendo
  Left = 0
  Top = 0
  Align = alClient
  BorderStyle = bsNone
  Caption = 'formNintendo'
  ClientHeight = 453
  ClientWidth = 723
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  OnCreate = FormCreate
  TextHeight = 15
  object pnlPrincipal: TPanel
    Left = 0
    Top = 0
    Width = 723
    Height = 453
    Align = alClient
    TabOrder = 0
    object sbPrincipal: TScrollBox
      Left = 1
      Top = 1
      Width = 721
      Height = 451
      Align = alClient
      TabOrder = 0
      UseWheelForScrolling = True
      object btnGBA: TSpeedButton
        Left = 0
        Top = 290
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Game Boy Advanced'
        ImageIndex = 2
        ImageName = 'gba'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        OnClick = btnGBAClick
        ExplicitTop = 284
        ExplicitWidth = 914
      end
      object btnGBC: TSpeedButton
        Left = 0
        Top = 145
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Game Boy Color'
        ImageIndex = 3
        ImageName = 'gbc'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = -3
        ExplicitTop = 139
        ExplicitWidth = 893
      end
      object btnGB: TSpeedButton
        Left = 0
        Top = 0
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Game Boy'
        ImageIndex = 1
        ImageName = 'gb'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = 3
        ExplicitTop = -6
      end
      object btnDS: TSpeedButton
        Left = 0
        Top = 1015
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Nintendo DS'
        ImageIndex = 0
        ImageName = 'ds'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = 3
        ExplicitTop = 554
        ExplicitWidth = 914
      end
      object btnGC: TSpeedButton
        Left = 0
        Top = 870
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'GameCube'
        ImageIndex = 4
        ImageName = 'gc'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = -3
        ExplicitTop = 399
        ExplicitWidth = 893
      end
      object btnN64: TSpeedButton
        Left = 0
        Top = 725
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Nintendo 64'
        ImageIndex = 5
        ImageName = 'n64'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = -3
        ExplicitTop = 254
        ExplicitWidth = 893
      end
      object btnSNES: TSpeedButton
        Left = 0
        Top = 580
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Super Nintendo'
        ImageIndex = 7
        ImageName = 'snes'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = -3
        ExplicitTop = 574
        ExplicitWidth = 893
      end
      object btnNES: TSpeedButton
        Left = 0
        Top = 435
        Width = 700
        Height = 145
        Align = alTop
        Caption = 'Nintendinho'
        ImageIndex = 6
        ImageName = 'nes'
        Images = vImgListIcones
        Enabled = False
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -29
        Font.Name = 'Calibri'
        Font.Style = []
        ParentFont = False
        Spacing = 25
        ExplicitLeft = 3
        ExplicitTop = 554
        ExplicitWidth = 914
      end
    end
    object btnVoltar: TButton
      Left = 25
      Top = 25
      Width = 75
      Height = 75
      ImageIndex = 8
      ImageName = 'Voltar'
      Images = vImgListIcones
      TabOrder = 1
      OnClick = btnVoltarClick
    end
  end
  object imgCollectionIcones: TImageCollection
    Images = <
      item
        Name = 'ds'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D4948445200000020000000200806000000737A7A
              F40000053E69545874584D4C3A636F6D2E61646F62652E786D7000000000003C
              3F787061636B657420626567696E3D22EFBBBF222069643D2257354D304D7043
              656869487A7265537A4E54637A6B633964223F3E0A3C783A786D706D65746120
              786D6C6E733A783D2261646F62653A6E733A6D6574612F2220783A786D70746B
              3D22584D5020436F726520352E352E30223E0A203C7264663A52444620786D6C
              6E733A7264663D22687474703A2F2F7777772E77332E6F72672F313939392F30
              322F32322D7264662D73796E7461782D6E7323223E0A20203C7264663A446573
              6372697074696F6E207264663A61626F75743D22220A20202020786D6C6E733A
              657869663D22687474703A2F2F6E732E61646F62652E636F6D2F657869662F31
              2E302F220A20202020786D6C6E733A70686F746F73686F703D22687474703A2F
              2F6E732E61646F62652E636F6D2F70686F746F73686F702F312E302F220A2020
              2020786D6C6E733A746966663D22687474703A2F2F6E732E61646F62652E636F
              6D2F746966662F312E302F220A20202020786D6C6E733A786D703D2268747470
              3A2F2F6E732E61646F62652E636F6D2F7861702F312E302F220A20202020786D
              6C6E733A786D704D4D3D22687474703A2F2F6E732E61646F62652E636F6D2F78
              61702F312E302F6D6D2F220A20202020786D6C6E733A73744576743D22687474
              703A2F2F6E732E61646F62652E636F6D2F7861702F312E302F73547970652F52
              65736F757263654576656E7423220A202020657869663A436F6C6F7253706163
              653D2231220A202020657869663A506978656C5844696D656E73696F6E3D2233
              32220A202020657869663A506978656C5944696D656E73696F6E3D223332220A
              20202070686F746F73686F703A436F6C6F724D6F64653D2233220A2020207068
              6F746F73686F703A49434350726F66696C653D22735247422049454336313936
              362D322E31220A202020746966663A496D6167654C656E6774683D223332220A
              202020746966663A496D61676557696474683D223332220A202020746966663A
              5265736F6C7574696F6E556E69743D2232220A202020746966663A585265736F
              6C7574696F6E3D2237322F31220A202020746966663A595265736F6C7574696F
              6E3D2237322F31220A202020786D703A4D65746164617461446174653D223230
              32332D30332D31335432323A35323A34372B31313A3030220A202020786D703A
              4D6F64696679446174653D22323032332D30332D31335432323A35323A34372B
              31313A3030223E0A2020203C786D704D4D3A486973746F72793E0A202020203C
              7264663A5365713E0A20202020203C7264663A6C690A202020202020786D704D
              4D3A616374696F6E3D2270726F6475636564220A202020202020786D704D4D3A
              736F6674776172654167656E743D22416666696E6974792050686F746F203220
              322E302E34220A202020202020786D704D4D3A7768656E3D22323032332D3033
              2D31335432323A35313A30332B31313A3030222F3E0A20202020203C7264663A
              6C690A20202020202073744576743A616374696F6E3D2270726F647563656422
              0A20202020202073744576743A736F6674776172654167656E743D2241666669
              6E6974792050686F746F203220322E302E34220A20202020202073744576743A
              7768656E3D22323032332D30332D31335432323A35323A34372B31313A303022
              2F3E0A202020203C2F7264663A5365713E0A2020203C2F786D704D4D3A486973
              746F72793E0A20203C2F7264663A4465736372697074696F6E3E0A203C2F7264
              663A5244463E0A3C2F783A786D706D6574613E0A3C3F787061636B657420656E
              643D2272223F3E4EE7BCDB000001816943435073524742204945433631393636
              2D322E31000028917591CF2B445114C73F3343E447140BC962125643CCD4C4C6
              62E457613146F9B59979F3DE8C9A1FAFF7DE24D92A5B45898D5F0BFE02B6CA5A
              2922255BD6C4063DE7CD532399733BF77CEEF7DE73BAF75CF0C6324AD6ACE885
              6CCE32A2A311FFECDCBCBFEA091FF5D412A235AE98FAE4F4488CB2F67E8BC789
              D7DD4EADF2E7FEB5DAA46A2AE0A9161E5474C3121E139E58B67487B7849B9574
              3C297C221C30E482C2378E9E70F9D9E194CB9F0E1BB1E810781B85FDA95F9CF8
              C54ADAC80ACBCBE9C8660ACACF7D9C97D4A9B9996989EDE26D98441925829F71
              8619224C1F033287E926488FAC2893DF5BCC9F222FB98ACC3A2B182C91228D45
              40D4825457256AA2AB3232AC38FDFFDB57530B05DDEA7511A87CB4EDD74EA8DA
              84AF0DDBFE38B0EDAF43F03DC079AE949FDF87FE37D1374A5AC71E34ACC1E945
              494B6CC3D93AB4DCEB71235E947CE25E4D839763A89F83A62BA859707BF6B3CF
              D11DC456E5AB2E616717BAE47CC3E2377AF667EFE5DBF6CB0000000970485973
              00000B1300000B1301009A9C18000003E9494441545885C597B14B2B5914C67F
              3349DED380121E16DAA4102C6C028A585998C6266C6369B38B01598B14B11004
              2B492568B67A856260AB3CB648A104ACD43F4012D0C22262316C1125A0A0E81A
              72CFDD623263269968741FEE5764EECC3DF77CDFB9F7DC7B6E0C5EA0F93C18ED
              0D5D2E973F85F9F0F090B5B53597DBEC66787474F4D3485FF315F4FB58281488
              442200ACAFAF532C16DF4D9A4824C864321E5F3D0B989F9F77DBE7E7E7241209
              060723980103D11A44D060B701118588468B204AD1683428168B6432198FAF9E
              05F8E1DBB708A15008AD05D11A5182D61A1044402985D68252C2CDCD4DAF6E7B
              17002062932A11D01A1101148D86604F8C6A8A826834FA730568B44DAE942BC6
              895A6BB197406BF43B3773D75D00707A7A8A65598E8226B96E9237102D282D28
              71042844D4ABFEDAD17506DA8D456B9CF0ECC8EDF5479CA8ED5C7066C015DE85
              B8AB80AEC64EC6A39ACBD12484E68F896EF6F542ECC0B3048542C1A3BE350A41
              21D8D3AB1A0A11FBBB8181699A98A6492818E24BE88B3BA6DD4FAB3F079E1988
              46A35896E579021F3A88BAF9ABD56ADD05B41A4722112CCB626B6BEB43E4EDFE
              9C67381CF6D8BC598C5656560088C5621D7D4F4F4F542A15F77D6C6C8CFEFE7E
              CECECE00585858E81853ABD53CC52808E8783C0EBCE4403BE6E6E6181A1AF27C
              7B7878607F7F9F783CCEC8C8881B71BD5E27168BD1D7D78765FD0DD8C952AFD7
              DDB1F1789CE3E3630D188613BD13E967607878987C3E0F60B839303333E36B7C
              7D7DCDCECECEBB49969696A8542ABE7EEFEEEEDC7610607373B3ABA3F1F17100
              7EFDED7744FF031868D128ADEDFD2F8246370B94C20C7CE5AF1F7FB2BCBC4C2E
              97E3F2F2F255A14180D5D55500CF326C6F6F0370707000C0E0C0570281BE37AB
              A161784FF7E65493CD6649A7D300A45229AF8076527F68B7E0BC560DCDB6EA92
              CD66013B41D3E934D16894ABAB2BB7DF639E4C26999898F0A51778A9865ABBD5
              D02617B7143B27642B2CCBA25AAD92CD66B9B8B8F0F4B90292C9A447C8C9C989
              377EE9AD1A6AED55E0904F4F4FB3B1B1C1FDFDBDBF8052A944A9546272729252
              A9D41946336A11FD4635ECBC10E4F3792CCBE2F6F6D6CD09076E0E94CB6592C9
              24A55209FF533180692A3410009432001333D02CD302D0C034439E51D1689474
              3A4DB55A259FCF934EA769341A9D024E4E4ED8DBDB73DB00B3B3B3AEE1F7EF7F
              F888EA0D4E51F34B4257C0ECEC6CC7BA3BD8DDDDFD3079BB887678B6616BC4AD
              989A9AFA1069381CF6F5E93B03DDA21F1818E8DAF716868787DF1C1B04C8E572
              2C2E2EBAA79E1FAEAEAE181D1D7DD59963D3FF8B50FBF1E46BF3F8F8E87977EF
              03A954AA638FFE573C3F3F7B9E4EBB79C3325A05C0FFF4F7FC5FD3049D5AC990
              7B870000000049454E44AE426082}
          end>
      end
      item
        Name = 'gb'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D494844520000002000000020080300000044A48A
              C600000063504C5445000000FFFFFFA3A3A35F6674736E802A2A2AD1D1D15A5A
              5A5C1E3C1919196663836664640000007878787B7B7B8A526E8E939C444444A3
              A7AEA4A4A4BDBDBDC0C2C75556836A6A6A86848D9CA893D5DBC0D6DBC4E7E7E7
              5B5B5B888888AF2B6CFF6767D0514C9B0000000274524E5300007693CD380000
              00D049444154785EB59387AEC3200C458319D97B74BEF1FF5F599B56251850AB
              4A3D4191E01E1C0222B3882682C81C8D01B32C8BD901A6D90B10C1134C045F00
              C50026A86AB35447A2DA2AC505A54E3B948A08971D9F08FFAF849FF73F71FE96
              F06A2721C89940ACC33418071324A6D33AAD2981D1173D1740EBAB0B8BBF8209
              408235288C54D0BA2CB57E56404241A3E0908935003519FD0B3B1F24350412BF
              29A921BFF870C14179CD2A8439E451619E17326AC8DBCE133AE2808C23BDA9E7
              57C8316F492A4B0ADB9CDD6ED1708478E437077E1D939769E144000000004945
              4E44AE426082}
          end>
      end
      item
        Name = 'gba'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D494844520000002000000020080300000044A48A
              C60000000467414D410000B18F0BFC6105000000206348524D00007A26000080
              840000FA00000080E8000075300000EA6000003A98000017709CBA513C000000
              63504C5445FFFFFF0000006E6E6EC66BFFC0C0C0F2F2F2A8BBCD76899B682C9E
              B848FF3200504A007300FF002557FF4873FF868686C2C2C26B8FFFB6B6B67A7A
              7A4A4A4AFF4848FFB848FFFF0000DC4900B93D9E9E9E323232AAAAAA3E3E3E62
              6262AA00FFFFFFFFD14968F50000000174524E530040E6D86600000001624B47
              440088051D480000000774494D4507E7030D071614715254B8000000DB494441
              5438CBDD93511782200C854502169588566699FDFF7FD918988C7CEF9C2E4F70
              3FEE8E6356D55F4914FAF26AC954AF94103BA574E123A195520111E86A6D8C04
              A6BD31788C080264173E8094842060926D991262104897CBAF882987006CFA48
              1CD161C029530082C1802653AA4100806B23E0D71581CE11E0FAB30B806F2ED7
              A1196EE3E829A1731081D661C44682734B893E96F099A844E8060100F72DC086
              0E2580121E99702B659920C4D44F4F5C536CD4926063C4CCFB38437CA0F0DE09
              7931D191FD8CCC0265B2C5DC71C61643F93DB6BFFE85B8DE07A613B71C5FCC08
              0000002574455874646174653A63726561746500323032332D30332D31335430
              373A32303A33322B30303A303004D39BF90000002574455874646174653A6D6F
              6469667900323030372D30332D31355431383A33363A33302B30303A30307658
              80A50000000049454E44AE426082}
          end>
      end
      item
        Name = 'gbc'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D494844520000002000000020080300000044A48A
              C600000099504C5445000000FFFFFF1E1E1E1A396B11111129558D2C54B4427D
              E01A1A1A709EEF1B325D2A4A993E71D30F0F0F1D3E76A2A2A2A5B09CC97A7A1B
              366431509C1C34631F487D9EB061BFC4AC8BA1B693B5F7D0CE9ADADFC7DBDFCA
              26439020457A9F045527528E03868604559F2A56A49F7A041919192C58A6ACC4
              BC049F54214B7F214B99D6A3A36464646D9CEFE18538EEE96EFB7474FCA489FC
              F7A02DA5EBF20000000274524E5300007693CD38000000ED49444154785E9DD3
              57AEC3201040D1307477A7F7F27A6FFB5F5C98244F66308EA55CF163CF916584
              189C6279243668CAB5D696E45EE41484854099201500D3AA0D2AAFC718587B45
              C04F1FF87060FEBC5CBED7BF7F516010CCA7D3BAFEFAEE024D9D6035ABAAD96A
              7DDB1768715096A634BBBB978703013D67D17BDC1464A7E24001E0E492122A00
              0A41F63FB4024400008400408043446D006780C38E7F582CAEEEC281FE6D5A00
              5C7664D30E9065B8469FA94E0380A209E714F07BED95EA8D7EE204C82DF7CD1B
              E7AF9280B17415AEA44892A2C0A7B10FF0760F2788600F20E56418DC6EC69C21
              3176991F01D95A2157668F0E2F0000000049454E44AE426082}
          end>
      end
      item
        Name = 'gc'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D494844520000002000000020080300000044A48A
              C60000004B504C54450000001313134C387C000000412F6830224B67489F9393
              931A1729ACACAC3A2A5D201C3224203A5B5B5B8857BA8F82A714111E26252F7D
              7D7D806CA4362755160F1D9B5CBE6A6A6ACCCCCC310975840000000174524E53
              0040E6D866000000BE49444154785E9590870EC3200C447B6685ECD5F1FF5FDA
              94B8227651AA3C09C9F81EF39681C9807B3206A61D402BC64C46923A39F7FEEE
              25A9630E829329917752206578250C03F1D2AAA233A14A64411F513105C1F106
              EDB2B427C2F90EFA0E5A90AFF8FF0F8E846057728E8843FA4C562B04CB49F6AC
              10CA64A1EFFB8766EB65C195B924D431BE8EC4584BA1099A460BF31CD2E0420B
              6300421ADF62BC2C287E85EEB9D185C085161034380A2873EDAB0191012CB061
              0C6032FB34E56FF8DA13F3B5BE2A3A0000000049454E44AE426082}
          end>
      end
      item
        Name = 'n64'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D494844520000002000000020080300000044A48A
              C60000006F504C544500000045414067645F5A56534847453C373454504F7970
              670000002B26209E9180524C4A7E766B8B817B49454244403F413C392F2A2739
              343168656045403A403C394A4C4A5A57565E5A5745413E8F8677625D524F4C45
              40533D534F4E2D282442475A2A221F5B5754332B20C4B3A3CCA633F800000001
              74524E530040E6D8660000016349444154785E75D089AEDB20108651CF0678CF
              9EDB7D7DFF67EC3FC315C58DFA4548983989700654FEDB1095DDBBFCD3C92B75
              9EBCCB89BA4E979DF0AD10257D7570AAE7A8EE768F2A88483DA78A00A20EE8B1
              03F82922E99B1DFAD10189A6DF87A61790A743F905DCCC7EB5CC6ED401BE3280
              6A6AA9DE3EECDBB655C07CBD8240F4F32DAAA026F7F3DF0FE61DC8B98AAD813A
              57AD20A3206F6F9F03681D7B152C4B2539AF807E879837B07801D606623ECF1D
              60E1DC40C20BEE3AA30AD675F13B622E72BF9FCF002E1A58116F042013484A67
              80441D98709E99D801738084E706262492EC00F00CA000650CB06680A9DD21E1
              19731DCB3BC864FE966EE35736327F550118955C7CF49BB23C908830B61EE938
              8C62E913628FE6E77326F112521300B604C1D183BE7CA7874498ABB10336225B
              A685B10461EBCB4FD9813173DCC37CA1F72D2906360E450D912C128BA86D1DC7
              1FA120637969C4D8E710DE70A83BFE03817B22BA0F57DA310000000049454E44
              AE426082}
          end>
      end
      item
        Name = 'nes'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D4948445200000020000000200403000000815467
              C700000030504C54450000000000000808081818182121212A2A2A3131314242
              425252635353536F6F6F73737B7C3D3D9410299F9FA8D4D4D45A4C9BC3000000
              0174524E530040E6D866000000A1494441542853636040078C8228408041FE3F
              0C7C2F2FAFFFFF119FC03F1081A262D5AAF5C34605CCB7DDBB21603B4C603FBA
              0A98C08F8E8E7E6C2A243A60A0C5C5C5A3A391416A95EFD95BAB4060595A5AD6
              AA854001AF5510B0A2A3A30B2CE033F7EC9C93B39054B8208017580006A02A54
              E0D28E8A42222E4E0C8CA1B191332367868686061929AB860A3030888646867A
              86BA8686060B1B9A06A247BF000300503956FE08E800430000000049454E44AE
              426082}
          end>
      end
      item
        Name = 'snes'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D494844520000002000000020080300000044A48A
              C600000039504C5445000000676767BFBFBF999999A9A9A9E4E4E47A60B2B6B6
              B6655195CCCCCC0000008181814F4F4F7676768A71C41B1B1BA48BE0C6C6C6D0
              D0D0669696000000000174524E530040E6D866000000DA49444154785E9D918B
              6A04210C00372FDF77D7F6FF3FB6C60642CE15DA0EA08C0C51F09AB423D7A2C9
              91760E90883C38F0FB20E7FC992376E413B26CE47005EF01C78036624022288E
              0AFD31E81BEF1310052762DC5CF1A5C82978F0C6C303B585652E16A89162998B
              5F41A8CCD5B7F0865E4A4AA914A00998740F044A7A3E3F52191A0C1308C19A60
              C18F84808094B136184B80E25F28D435E826721B207AF09F09B2D882F522B235
              88058C0838B1D5852DA04EC0B556B609C033609B60DF09758C5181178053704A
              BB8CD6804584A1292E97F36ACAEB46BE0171F8140875A7116F0000000049454E
              44AE426082}
          end>
      end
      item
        Name = 'Voltar'
        SourceImages = <
          item
            Image.Data = {
              89504E470D0A1A0A0000000D49484452000000320000003208060000001E3F88
              B1000000097048597300000B1300000B1301009A9C180000009349444154789C
              EDD9B10DC2401404D169E29FA0FF4A8810C82438A01C2CA40B100DB0FF34AF82
              5B8D03FB0C923A18C003B8D07CC40EBC811B4D15F09C235EC089861C91C21229
              2C91C212292C91C212292C91A27C150F512B94F8D8E6887D7EAEB6B5AD32A47E
              1EAD338D956342956542956542956542592695655259269565522D55667CFD9E
              BED3DC987700D77F1F445AD501C974741F2DBBD7D90000000049454E44AE4260
              82}
          end>
      end>
    Left = 101
    Top = 377
  end
  object vImgListIcones: TVirtualImageList
    Images = <
      item
        CollectionIndex = 0
        CollectionName = 'ds'
        Name = 'ds'
      end
      item
        CollectionIndex = 1
        CollectionName = 'gb'
        Name = 'gb'
      end
      item
        CollectionIndex = 2
        CollectionName = 'gba'
        Name = 'gba'
      end
      item
        CollectionIndex = 3
        CollectionName = 'gbc'
        Name = 'gbc'
      end
      item
        CollectionIndex = 4
        CollectionName = 'gc'
        Name = 'gc'
      end
      item
        CollectionIndex = 5
        CollectionName = 'n64'
        Name = 'n64'
      end
      item
        CollectionIndex = 6
        CollectionName = 'nes'
        Name = 'nes'
      end
      item
        CollectionIndex = 7
        CollectionName = 'snes'
        Name = 'snes'
      end
      item
        CollectionIndex = 8
        CollectionName = 'Voltar'
        Name = 'Voltar'
      end>
    ImageCollection = imgCollectionIcones
    Width = 64
    Height = 64
    Left = 109
    Top = 305
  end
end
