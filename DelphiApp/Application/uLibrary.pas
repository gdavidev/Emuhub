unit uLibrary;

interface
Function PegaDiretorio: String;

implementation

uses
  System.Win.Registry, Winapi.Windows;

Function PegaDiretorio: String;
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
        Result := Reg.ReadString('Diretorio');
      end;

      // Fecha a chave ap�s ler o valor
      Reg.CloseKey;
    end;
  finally
    // Libera o recurso TRegistry
    Reg.Free;
  end;
end;

end.
