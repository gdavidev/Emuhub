unit uGBA;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ExtCtrls, Vcl.StdCtrls,
  System.ImageList, Vcl.ImgList, Vcl.VirtualImageList, Vcl.BaseImageCollection,
  Vcl.ImageCollection;

type
  TformGBA = class(TForm)
    pnlPrincipal: TPanel;
    btnVoltar: TButton;
    imgCollectionIcones: TImageCollection;
    vImgListIcones: TVirtualImageList;
    sbPrincipal: TScrollBox;
    ImageList: TImageList;
    procedure btnVoltarClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
    procedure CarregaRoms;
    procedure PegaDiretorio;
    procedure BotaoClick(Sender: TObject);
  public
    { Public declarations }
  end;

var
  formGBA: TformGBA;

implementation

uses
  uPrincipal, System.IOUtils, System.Win.Registry,
   System.Generics.Collections, ShellAPI, Vcl.Imaging.pngimage, Vcl.Buttons;

var
  DiretorioPadrao: String;

{$R *.dfm}

procedure TformGBA.PegaDiretorio;
var
  Reg: TRegistry;
begin
  // Cria a inst�ncia do TRegistry
  Reg := TRegistry.Create(KEY_READ);
  try
    // Define o root onde a chave est� (HKEY_CURRENT_USER, HKEY_LOCAL_MACHINE, etc.)
    Reg.RootKey := HKEY_CLASSES_ROOT;

    // Abre a chave onde o valor est� armazenado
    if Reg.OpenKeyReadOnly('\EmuHub') then
    begin
      // Verifica se o valor existe
      if Reg.ValueExists('Diretorio') then
      begin
        // L� o valor
        DiretorioPadrao := Reg.ReadString('Diretorio');
      end;

      // Fecha a chave ap�s ler o valor
      Reg.CloseKey;
    end;
  finally
    // Libera o recurso TRegistry
    Reg.Free;
  end;
end;

procedure TformGBA.CarregaRoms;
var
  Diretorio: String;
  Arquivos: TArray<string>;
  Arquivo: string;
  BotoesRoms: TList<TSpeedButton>;
  Botao: TSpeedButton;
  I: Integer;
  PNGImage: TPNGImage; // Para imagens PNG
  Bitmap: TBitmap; // Para bitmap
begin
  Diretorio := DiretorioPadrao + 'GBA\Roms';

  if not TDirectory.Exists(Diretorio) then
  begin
    pnlPrincipal.Caption := 'Nenhuma Rom de GBA';
    Exit;
  end;

  Arquivos := TDirectory.GetFiles(Diretorio, '*.gba', TSearchOption.soTopDirectoryOnly);

  BotoesRoms := TList<TSpeedButton>.Create; // Inicializa a lista de bot�es
  try
    I := 0;
    for Arquivo in Arquivos do
    begin
      // Cria o bot�o
      Botao := TSpeedButton.Create(Self);
      Botao.Parent := sbPrincipal; // Define o painel como pai do bot�o
      Botao.Align := alTop;
      Botao.Height := 145;
      Botao.Name := 'btn' + IntToStr(I); // Use o �ndice ou outra forma para nomear o bot�o

      // Define o Caption do bot�o sem a extens�o .gba
      Botao.Caption := ChangeFileExt(ExtractFileName(Arquivo), '');

      Botao.OnClick := BotaoClick;

      // Criar novas inst�ncias para cada itera��o
      PNGImage := TPNGImage.Create;
      Bitmap := TBitmap.Create;
      try
        // Verifica se a imagem existe
        if FileExists(Diretorio + '\' + ChangeFileExt(ExtractFileName(Arquivo), '.png')) then
        begin
          // Carregar a imagem de um arquivo
          PNGImage.LoadFromFile(Diretorio + '\' + ChangeFileExt(ExtractFileName(Arquivo), '.png'));

          // Converter o PNG para um Bitmap
          Bitmap.Assign(PNGImage);

          // Adicionar o Bitmap � ImageList
          ImageList.Add(Bitmap, nil); // O segundo par�metro � a m�scara, se necess�rio

          // Alternativamente, se voc� quiser adicionar uma m�scara:
          // ImageList.AddMasked(Bitmap, clFuchsia); // Usando uma cor de m�scara

          // Define a imagem do bot�o
          Botao.Images := ImageList;
          Botao.ImageIndex := ImageList.Count - 1; // Usar o �ndice da imagem rec�m-adicionada
        end;

      finally
        Bitmap.Free;     // Libera o Bitmap ap�s adicionar
        PNGImage.Free;   // Libera a imagem PNG
      end;

      // Adiciona o bot�o � lista de bot�es
      BotoesRoms.Add(Botao);
      I := I + 1;
    end;
  finally
    BotoesRoms.Free; // Certifique-se de liberar a lista de bot�es se n�o precisar mais
  end;
end;


procedure TformGBA.BotaoClick(Sender: TObject);
var
  Botao: TSpeedButton;
  Comando: string;
begin
  Botao := Sender as TSpeedButton;
  Comando := 'start /b ' + DiretorioPadrao + 'GBA\mGBA.exe -f ' +
  '"' + DiretorioPadrao + 'GBA\Roms\' + Botao.Caption + '.gba"';
  // Executa o comando no CMD
  ShellExecute(0, 'open', 'cmd.exe', PChar('/C ' + Comando), nil, SW_SHOWNORMAL);
end;

procedure TformGBA.FormCreate(Sender: TObject);
begin
  PegaDiretorio;
  CarregaRoms;
end;

procedure TformGBA.btnVoltarClick(Sender: TObject);
begin
  TformPrincipal(Owner).TrocaForm('Nintendo');
end;

end.
