CREATE PROCEDURE sp_InsertarEstudiante
	@nombre VARCHAR(100),
	@documento VARCHAR(100)
AS
BEGIN
	INSERT INTO tbl_estudiantes (nombre, documento)
	VALUES (@nombre, @documento);
END;

CREATE PROCEDURE sp_ObtenerEstudiantes
AS
BEGIN
	SELECT id, nombre, documento FROM tbl_estudiantes;
END;

CREATE PROCEDURE sp_ObtenerEstudiantePorId
	@id INT
AS
BEGIN
	SELECT id, nombre, documento 
	FROM tbl_estudiantes
	WHERE id = @id;
END;

CREATE PROCEDURE sp_ObtenerEstudiantePorDocumento
	@documento INT
AS
BEGIN
	SELECT id, nombre, documento 
	FROM tbl_estudiantes
	WHERE documento = @documento;
END;

CREATE PROCEDURE sp_ActualizarEstudiantes
	
	@id INT,
	@nombre VARCHAR(100),
	@documento VARCHAR(100)

AS
BEGIN
	UPDATE tbl_estudiantes
	SET nombre = @nombre, documento = @documento
	WHERE id = @id

END;



CREATE PROCEDURE sp_EliminarEstudiante
	@id INT
AS
BEGIN
	DELETE FROM tbl_estudiantes
	WHERE id = @id
END;

