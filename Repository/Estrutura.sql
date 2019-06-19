-- Tabela Contas Receber --
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

-- Tabela Contas Receber -- 
CREATE TABLE contas_receber(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	valor DECIMAL(10,2),
	tipo VARCHAR(100),
	descricao TEXT,
	status VARCHAR(100)

);
INSERT INTO contas_receber (nome, valor, tipo, descricao, status)
VALUES
('Desenvolvimento App', 3500, 'pagamento', 'trabalho de desenvolvimento', 'pendente');


-- Tabela Endereços -- 
DROP TABLE enderecos;
CREATE TABLE enderecos(

	id INT PRIMARY KEY IDENTITY(1,1),
	uf VARCHAR(2),
	cidade VARCHAR(100),
	lagradouro VARCHAR(100),
	cep VARCHAR(25),
	numero VARCHAR(100),
	complemento VARCHAR(100)

);

INSERT INTO enderecos (uf, cidade, lagradouro, cep , numero , complemento)
VALUES
('SC', 'Blumenau', '48151', '89021-000', '1930', 'Depois do Posto');

SELECT * FROM enderecos

