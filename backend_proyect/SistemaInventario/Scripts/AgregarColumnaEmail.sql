-- Script para agregar la columna Email a la tabla Usuario si no existe
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND name = 'Email')
BEGIN
    ALTER TABLE [dbo].[Usuario] ADD [Email] NVARCHAR(100) NULL;
    
    -- Actualizar los usuarios existentes con un email predeterminado
    UPDATE [dbo].[Usuario] 
    SET [Email] = NombreUsuario + '@example.com';
    
    PRINT 'Columna Email agregada a la tabla Usuario y valores predeterminados establecidos.';
END
ELSE
BEGIN
    PRINT 'La columna Email ya existe en la tabla Usuario.';
END
