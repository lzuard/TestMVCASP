<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'UtilList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список утилизаций',
        linkToCreate: '/util/create',
        createCaption: 'Создать утилизацию',
        tableHeaders: [
          'Номер ТТН',
          'Утилизатор',
          'Номер акта утилизации',
          'Дата отгрузки'
        ],
        tableData: [
          {
            ttn: '29873/НУ1',
            utilizator: 'УтилПро',
            actOfUtil: '53463426',
            utilDate: '21.10.2021'
          }
        ],
        sortTypes: [
          'Номер ТТН',
          'Утилизатор',
          'Номер акта утилизации'
        ]
      }
    }
  }
}
</script>
