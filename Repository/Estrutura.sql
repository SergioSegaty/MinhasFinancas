DROP TABLE contas_pagar;
CREATE TABLE contas_pagar (

	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(10,2),
	tipo VARCHAR(100),
	descricao TEXT,
	status VARCHAR(100),
);

INSERT INTO contas_pagar (nome, valor, tipo, descricao, status)
VALUES 
('Net' , 135.00, 'conta_internet', 'conta de internet', 'Pago'),
('SKY' , 99.00, 'conta_tv', 'conta da tv', 'Pago');

SELECT * FROM contas_pagar;