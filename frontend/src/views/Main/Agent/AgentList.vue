<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'AgentList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список контрагентов',
        createCaption: 'Создать контрагента',
        tableHeaders: [
          'Тип',
          'Адрес',
          'Наименование',
          'ИНН',
          'Расчетный счет',
          'Телефон',
          'Электронная почта'
        ],
        tableData: [
          {
            type: 'ТК',
            address: 'Адрес',
            name: 'Автотрейд',
            inn: '54352544235',
            bill: '5435236267',
            phone: '+799970012312',
            email: 'admin@gmail.com'
          }
        ],
        sortTypes: [
          'Тип',
          'Адрес',
          'Наименование',
          'ИНН',
          'Расчетный счет',
          'Телефон',
          'Электронная почта'
        ]
      }
    }
  }
}
</script>
