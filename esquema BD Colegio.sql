USE [master]
GO
/****** Object:  Database [db_Colegio]    Script Date: 21/04/2025 6:46:30 ******/
CREATE DATABASE [db_Colegio]
GO
USE [db_Colegio]
GO
/****** Object:  Table [dbo].[tbl_docente]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_docente](
	[id] [int] NOT NULL IDENTITY (1,1),
	[nombreCompleto] [varchar](100) NULL,
	[especialidad] [varchar](50) NULL,
	[correo] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_estudianteGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_estudianteGrado](
	[id] [int] NOT NULL IDENTITY (1,1),
	[estudianteId] [int] NULL,
	[gradoId] [int] NULL,
	[anioLectivo] [int] NULL,
	[promovido] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_estudiantes]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_estudiantes](
	[id] [int] NOT NULL IDENTITY (1,1),
	[nombre] [varchar](100) NULL,
	[fechaNacimiento] [date] NULL,
	[tipoDocumento] [varchar](20) NULL,
	[documento] [varchar](20) NULL,
	[direccion] [varchar](150) NULL,
	[telefono] [varchar](20) NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_grado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_grado](
	[id] [int] NOT NULL IDENTITY (1,1),
	[nombre] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_materia]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_materia](
	[id] [int] NOT NULL IDENTITY (1,1),
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_materiaPorGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_materiaPorGrado](
	[id] [int] NOT NULL IDENTITY (1,1),
	[gradoId] [int] NULL,
	[materiaId] [int] NULL,
	[docenteId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_nota]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_nota](
	[id] [int] NOT NULL IDENTITY (1,1),
	[estudianteGradoId] [int] NULL,
	[materiaPorGradoId] [int] NULL,
	[nombreEvaluacion] [varchar](100) NULL,
	[calificacion] [decimal](3, 1) NULL,
	[fecha] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_docente] ([nombreCompleto], [especialidad], [correo], [telefono], [activo]) VALUES (N'Josefino Perez', N'Etica', N'josefino@mail.com', N'322154641', 1)
GO
ALTER TABLE [dbo].[tbl_estudianteGrado]  WITH CHECK ADD FOREIGN KEY([estudianteId])
REFERENCES [dbo].[tbl_estudiantes] ([id])
GO
ALTER TABLE [dbo].[tbl_estudianteGrado]  WITH CHECK ADD FOREIGN KEY([gradoId])
REFERENCES [dbo].[tbl_grado] ([id])
GO
ALTER TABLE [dbo].[tbl_materiaPorGrado]  WITH CHECK ADD FOREIGN KEY([docenteId])
REFERENCES [dbo].[tbl_docente] ([id])
GO
ALTER TABLE [dbo].[tbl_materiaPorGrado]  WITH CHECK ADD FOREIGN KEY([gradoId])
REFERENCES [dbo].[tbl_grado] ([id])
GO
ALTER TABLE [dbo].[tbl_materiaPorGrado]  WITH CHECK ADD FOREIGN KEY([materiaId])
REFERENCES [dbo].[tbl_materia] ([id])
GO
ALTER TABLE [dbo].[tbl_nota]  WITH CHECK ADD FOREIGN KEY([estudianteGradoId])
REFERENCES [dbo].[tbl_estudianteGrado] ([id])
GO
ALTER TABLE [dbo].[tbl_nota]  WITH CHECK ADD FOREIGN KEY([materiaPorGradoId])
REFERENCES [dbo].[tbl_materiaPorGrado] ([id])
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarDocente]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarDocente]
    @id INT,
    @nombreCompleto VARCHAR(100),
    @especialidad VARCHAR(50),
    @correo VARCHAR(100),
    @telefono VARCHAR(20),
    @activo BIT
AS
BEGIN
    UPDATE tbl_docente
    SET nombreCompleto = @nombreCompleto,
        especialidad = @especialidad,
        correo = @correo,
        telefono = @telefono,
        activo = @activo
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEstudiante]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarEstudiante]
	
	@id INT,
	@nombre VARCHAR(100),
    @fechaNacimiento DATE,
    @tipoDocumento VARCHAR(20),
    @documento VARCHAR(20),
    @direccion VARCHAR(150),
    @telefono VARCHAR(20),
    @activo BIT

AS
BEGIN
	UPDATE tbl_estudiantes
	SET nombre = @nombre,  fechaNacimiento = @fechaNacimiento, tipoDocumento = @tipoDocumento, documento = @documento, 
	direccion = @direccion, telefono = @telefono, activo = @activo
	WHERE id = @id

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEstudianteGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarEstudianteGrado]
    @id INT,
    @estudianteId INT,
    @gradoId INT,
    @anioLectivo INT,
    @promovido BIT
AS
BEGIN
    UPDATE tbl_estudianteGrado
    SET estudianteId = @estudianteId,
        gradoId = @gradoId,
        anioLectivo = @anioLectivo,
        promovido = @promovido
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarGrado]
    @id INT,
    @nombre VARCHAR(20)
AS
BEGIN
    UPDATE tbl_grado
    SET nombre = @nombre
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarMateria]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarMateria]
    @id INT,
    @nombre VARCHAR(100)
AS
BEGIN
    UPDATE tbl_materia
    SET nombre = @nombre
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarMateriaPorGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarMateriaPorGrado]
    @id INT,
    @gradoId INT,
    @materiaId INT,
    @docenteId INT
AS
BEGIN
    UPDATE tbl_materiaPorGrado
    SET gradoId = @gradoId,
        materiaId = @materiaId,
        docenteId = @docenteId
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarNota]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarNota]
    @id INT,
    @estudianteGradoId INT,
    @materiaPorGradoId INT,
    @nombreEvaluacion VARCHAR(100),
    @calificacion DECIMAL(3,1),
    @fecha DATE
AS
BEGIN
    UPDATE tbl_nota
    SET estudianteGradoId = @estudianteGradoId,
        materiaPorGradoId = @materiaPorGradoId,
        nombreEvaluacion = @nombreEvaluacion,
        calificacion = @calificacion,
        fecha = @fecha
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarDocente]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarDocente]
    @id INT
AS
BEGIN
    DELETE FROM tbl_docente WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEstudiante]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarEstudiante]
	@id INT
AS
BEGIN
	DELETE FROM tbl_estudiantes
	WHERE id = @id
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEstudianteGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarEstudianteGrado]
    @id INT
AS
BEGIN
    DELETE FROM tbl_estudianteGrado WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarGrado]
    @id INT
AS
BEGIN
    DELETE FROM tbl_grado WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMateria]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarMateria]   @id INT
AS
BEGIN
    DELETE FROM tbl_materia WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMateriaPorGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarMateriaPorGrado]
    @id INT
AS
BEGIN
    DELETE FROM tbl_materiaPorGrado WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarNota]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarNota]
    @id INT
AS
BEGIN
    DELETE FROM tbl_nota WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarDocente]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarDocente]
    @nombreCompleto VARCHAR(100),
    @especialidad VARCHAR(50),
    @correo VARCHAR(100),
    @telefono VARCHAR(20),
    @activo BIT
AS
BEGIN
    INSERT INTO tbl_docente (nombreCompleto, especialidad, correo, telefono, activo)
    VALUES (@nombreCompleto, @especialidad, @correo, @telefono, @activo);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarEstudiante]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarEstudiante]
	@nombre VARCHAR(100),
    @fechaNacimiento DATE,
    @tipoDocumento VARCHAR(20),
    @documento VARCHAR(20),
    @direccion VARCHAR(150),
    @telefono VARCHAR(20),
    @activo BIT
AS
BEGIN
	INSERT INTO tbl_estudiantes (nombre, fechaNacimiento, tipoDocumento, documento, direccion, telefono, activo)
	VALUES (@nombre, @fechaNacimiento, @tipoDocumento, @documento, @direccion, @telefono, @activo);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarEstudianteGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarEstudianteGrado]
    @estudianteId INT,
    @gradoId INT,
    @anioLectivo INT,
    @promovido BIT
AS
BEGIN
    INSERT INTO tbl_estudianteGrado (estudianteId, gradoId, anioLectivo, promovido)
    VALUES (@estudianteId, @gradoId, @anioLectivo, @promovido);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarGrado]
    @nombre VARCHAR(20)
AS
BEGIN
    INSERT INTO tbl_grado (nombre)
    VALUES (@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarMateria]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarMateria]
    @nombre VARCHAR(100)
AS
BEGIN
    INSERT INTO tbl_materia (nombre)
    VALUES (@nombre);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarMateriaPorGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarMateriaPorGrado]
    @gradoId INT,
    @materiaId INT,
    @docenteId INT
AS
BEGIN
    INSERT INTO tbl_materiaPorGrado (gradoId, materiaId, docenteId)
    VALUES (@gradoId, @materiaId, @docenteId);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarNota]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarNota]
    @estudianteGradoId INT,
    @materiaPorGradoId INT,
    @nombreEvaluacion VARCHAR(100),
    @calificacion DECIMAL(3,1),
    @fecha DATE
AS
BEGIN
    INSERT INTO tbl_nota (estudianteGradoId, materiaPorGradoId, nombreEvaluacion, calificacion, fecha)
    VALUES (@estudianteGradoId, @materiaPorGradoId, @nombreEvaluacion, @calificacion, @fecha);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDocentePorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerDocentePorId]
    @id INT
AS
BEGIN
    SELECT * FROM tbl_docente WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEstudianteGradoPorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerEstudianteGradoPorId]
    @id INT
AS
BEGIN
    SELECT * FROM tbl_estudianteGrado WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEstudiantePorDocumento]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerEstudiantePorDocumento]
	@documento INT
AS
BEGIN
	SELECT id, nombre, documento 
	FROM tbl_estudiantes
	WHERE documento = @documento;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEstudiantePorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerEstudiantePorId]
	@id INT
AS
BEGIN
	SELECT id, nombre, fechaNacimiento, tipoDocumento, documento, direccion, telefono, activo
	FROM tbl_estudiantes
	WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerEstudiantes]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerEstudiantes]
AS
BEGIN
	SELECT id, nombre, fechaNacimiento, tipoDocumento, documento, direccion, telefono, activo FROM tbl_estudiantes;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerGradoPorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerGradoPorId]
    @id INT
AS
BEGIN
    SELECT * FROM tbl_grado WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerMateriaPorGradoPorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerMateriaPorGradoPorId]
    @id INT
AS
BEGIN
    SELECT * FROM tbl_materiaPorGrado WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerMateriaPorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerMateriaPorId]
    @id INT
AS
BEGIN
    SELECT * FROM tbl_materia WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerNotaPorId]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerNotaPorId]
    @id INT
AS
BEGIN
    SELECT * FROM tbl_nota WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodasMaterias]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTodasMaterias]
AS
BEGIN
    SELECT * FROM tbl_materia;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodasMateriasPorGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTodasMateriasPorGrado]
AS
BEGIN
    SELECT * FROM tbl_materiaPorGrado;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodasNotas]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTodasNotas]
AS
BEGIN
    SELECT * FROM tbl_nota;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodosDocentes]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTodosDocentes]
AS
BEGIN
    SELECT * FROM tbl_docente;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodosEstudiantesGrado]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTodosEstudiantesGrado]
AS
BEGIN
    SELECT * FROM tbl_estudianteGrado;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerTodosGrados]    Script Date: 21/04/2025 6:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerTodosGrados]
AS
BEGIN
    SELECT * FROM tbl_grado;
END
GO
USE [master]
GO
ALTER DATABASE [db_Colegio] SET  READ_WRITE 
GO
