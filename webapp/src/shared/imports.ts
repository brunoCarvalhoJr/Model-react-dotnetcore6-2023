const routes = require.context(
    // O caminho relativo da pasta
    "../modules",
    // Se deve ou não olhar subpastas
    true,
    // Expressão regular para localizar nomes
    /.route./,
);

const stores = require.context(
    // O caminho relativo da pasta
    "../modules",
    // Se deve ou não olhar subpastas
    true,
    // Expressão regular para localizar nomes
    /.store./,
);

export { routes, stores };
