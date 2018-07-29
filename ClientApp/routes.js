
const CounterExample = () => import('components/counter-example');
const FetchData = () => import('components/fetch-data');
const FetchDataDb = () => import('components/fetch-data-db');
const AuthJwt = () => import('components/auth-jwt');
const HomePage = () => import('components/home-page');

export const routes = [
    { path: '/', alias: "*", component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/counter', component: CounterExample, display: 'Counter', style: 'glyphicon glyphicon-education' },
    { path: '/fetch-data', component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' },
    { path: '/fetch-data-db', component: FetchDataDb, display: 'Fetch data Db', style: 'glyphicon glyphicon-th-list' },
    { path: '/auth-jwt', component: AuthJwt, display: 'Auth JWT', style: 'glyphicon glyphicon-user' }
]
