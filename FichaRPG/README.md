# Ficha RPG - Sistema de Gerenciamento de Personagens

Sistema web ASP.NET Core MVC para gerenciar personagens de RPG com integração para OBS Studio.

## 🎮 Funcionalidades

- **Cadastro de Personagens**: Crie e gerencie personagens com nome, classe, vida e sanidade
- **Controle do Mestre**: Interface completa para o mestre controlar atributos dos personagens
- **Gerenciamento de Vida**: Aplique dano e cure personagens em tempo real
- **Controle de Sanidade**: Altere a sanidade dos personagens
- **Overlay para OBS**: View especial com fundo transparente para integração com OBS Studio
- **Interface Moderna**: Design responsivo com gradientes e animações

## 🚀 Como Executar

1. **Navegue até a pasta do projeto:**
   ```bash
   cd FichaRPG
   ```

2. **Execute o projeto:**
   ```bash
   dotnet run
   ```

3. **Acesse a aplicação:**
   - Painel do Mestre: `https://localhost:5001/Mestre`
   - Overlay para OBS: `https://localhost:5001/Overlay`

## 📦 Publicar Aplicação

Para criar uma versão publicada e otimizada da aplicação:

```bash
dotnet publish -c Release -o ./publish
```

Isso irá:
- Compilar a aplicação em modo Release (otimizado)
- Gerar todos os arquivos necessários na pasta `./publish`
- Incluir o banco de dados SQLite

Para executar a versão publicada:

```bash
cd publish
dotnet FichaRPG.dll
```

**Nota**: A aplicação publicada ainda precisa do .NET Runtime 8.0 instalado para funcionar.

## 🎥 Integração com OBS

1. No OBS, adicione uma nova fonte do tipo **"Browser"**
2. Configure a URL: `https://localhost:5001/Overlay`
3. Defina as dimensões desejadas (recomendado: 400x600)
4. Marque a opção **"Desligar a origem quando não estiver visível"** para melhor performance
5. A tela do overlay atualiza automaticamente a cada 2 segundos

## 📋 Estrutura do Projeto

```
FichaRPG/
├── Controllers/
│   ├── MestreController.cs     # Gerenciamento de personagens
│   └── OverlayController.cs    # Overlay para OBS
├── Models/
│   └── Personagem.cs           # Modelo de dados
├── Services/
│   └── PersonagemService.cs    # Lógica de negócio
├── Views/
│   ├── Mestre/
│   │   ├── Index.cshtml        # Lista de personagens
│   │   ├── Criar.cshtml        # Criar personagem
│   │   └── Editar.cshtml       # Editar personagem
│   └── Overlay/
│       └── Index.cshtml        # View para OBS
└── wwwroot/
    └── css/
        └── site.css            # Estilos personalizados
```

## 🎨 Recursos Visuais

- **Gradientes modernos** com tema escuro
- **Barras de progresso animadas** para vida e sanidade
- **Efeito de pulsação** quando a vida está crítica (≤25%)
- **Animações suaves** em todas as interações
- **Design responsivo** para diferentes resoluções

## 🛠️ Tecnologias

- ASP.NET Core 8.0
- MVC Pattern
- Razor Views
- CSS3 com animações
- HTML5

## 📝 Uso

### Criar Personagem
1. Clique em "Novo Personagem"
2. Preencha nome, classe, vida máxima/atual e sanidade máxima/atual
3. Opcionalmente adicione uma URL de imagem

### Controlar Personagem
- **Dano**: Digite o valor e clique em "Dano" para reduzir a vida
- **Curar**: Digite o valor e clique em "Curar" para restaurar vida
- **Sanidade**: Digite valor positivo ou negativo e clique em "Alterar"
- **Ativar/Desativar**: Controla se o personagem aparece no overlay
- **Editar**: Altere qualquer atributo do personagem
- **Remover**: Exclua permanentemente o personagem

### Overlay no OBS
Os personagens marcados como "Ativos" aparecem automaticamente no overlay com:
- Nome e classe
- Barra de vida com porcentagem
- Barra de sanidade com porcentagem
- Atualização automática a cada 2 segundos

## ⚡ Dicas

- Use valores negativos na sanidade para reduzir
- A vida crítica (≤25%) ativa uma animação de alerta
- Personagens inativos ficam acinzentados no painel do mestre
- O overlay tem fundo transparente, perfeito para o OBS
