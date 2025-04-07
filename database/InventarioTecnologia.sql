
USE InventarioTecnologia;
GO

CREATE TABLE Categorias (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Proveedores (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    contacto NVARCHAR(100),
    direccion NVARCHAR(MAX)
);

CREATE TABLE Productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    descripcion NVARCHAR(MAX),
    id_categoria INT,
    precio_compra DECIMAL(10,2),
    precio_venta DECIMAL(10,2),
    stock INT DEFAULT 0,
    id_proveedor INT,
    FOREIGN KEY (id_categoria) REFERENCES Categorias(id_categoria),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);

CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    contacto NVARCHAR(100)
);

CREATE TABLE OrdenesCompra (
    id_orden_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT,
    fecha DATE,
    costo_total DECIMAL(10,2),
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);

CREATE TABLE DetallesOrdenCompra (
    id_detalle_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_compra INT,
    id_producto INT,
    cantidad INT,
    costo DECIMAL(10,2),
    FOREIGN KEY (id_orden_compra) REFERENCES OrdenesCompra(id_orden_compra),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);

CREATE TABLE OrdenesVenta (
    id_orden_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT,
    fecha DATE,
    total DECIMAL(10,2),
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
);

CREATE TABLE DetallesOrdenVenta (
    id_detalle_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_orden_venta INT,
    id_producto INT,
    cantidad INT,
    precio DECIMAL(10,2),
    FOREIGN KEY (id_orden_venta) REFERENCES OrdenesVenta(id_orden_venta),
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
