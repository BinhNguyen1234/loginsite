import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react-swc';
import basicSsl from '@vitejs/plugin-basic-ssl';
import tsconfig from './tsconfig.json';

import nodeResolve from '@rollup/plugin-node-resolve';
const aliasFromTsConfig = Object.entries(tsconfig.compilerOptions.paths);
const aliasForVite = aliasFromTsConfig.map((e) => {
    return {
        find: e[0].replace(/\/\*$/, ''),
        replacement: '/' + e[1][0].replace(/\/\*$/, '')
    };
}).concat(
    {
        find: 'src',
        replacement: '/src'
    }
);
const PORT_FOR_PROXY = process.env.ASPNETCORE_HTTPS_PORT;
export default defineConfig({
    plugins: [nodeResolve(), react(), basicSsl()],
    server: {
        https: true,
        proxy: {
            '/api': {
                target: `https://localhost:${PORT_FOR_PROXY}`,
                secure: false
            }
        }
    },

    resolve: {
        extensions: ['.ts', '.tsx', '.slice', '.svg'],
        alias: aliasForVite
    },
    root: './'
});
